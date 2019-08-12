using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Napisać strukturę Zespolona do obsługi liczb zespolonych. 
//Przeciążyć odpowiednie operatory: true i false, 
//- jednoargumentowy, ~ jako sprzężenie, ! jako moduł,
//+, - , *, /  , ==, !=.


public struct Zespolona
{
    double real, imag;//pola

    public double Real
    { get { return real; } }

    public double Imag
    { get { return imag; } }

    //konstruktor 
    public Zespolona(double real, double imag)
    {
        this.real = real;
        this.imag = imag;
    }

    // konstruktor CreateFromPolar, dodatkowy parametr bo też double, double
    public Zespolona(double promien, double argument, int i)
    {
        real = promien * System.Math.Cos(argument);
        imag = promien * System.Math.Sin(argument);
    }

    //inne metody

    // ToString
    public override string ToString()
    {
        string s = Real.ToString();
        if (Imag >= 0) s += "+i"; else s += "-i";
        s += Math.Abs(Imag);
        return s;
    }

    // +
    public static Zespolona operator +(Zespolona z1, Zespolona z2)
    {
        return new Zespolona(z1.real + z2.real, z1.imag + z2.imag);
    }

    // mogę przeciążać wielokrotnie
    public static Zespolona operator +(Zespolona z1, double d)
    {
        return new Zespolona(z1.real + d, z1.imag);
    }
    public static Zespolona operator +(double d, Zespolona z1)
    {
        return z1 + d;
    }

    // niezbyt sensownie ale formalnie OK
    public static double operator +(Zespolona z1, int d)// NIE MUSZĘ zwracac Zespolona
    {
        return z1.real + d;
    }

    // true i false
    public static bool operator false(Zespolona z1)
    {
        return z1.real == 0 && z1.imag == 0;
    }
    public static bool operator true(Zespolona z1)
    {
        return z1.real != 0 && z1.imag != 0;
        // lepiej jak poniżej, powyżej może coś nie mieć żadnej wartości
        //return  z1.real != 0 || z1.imag != 0
    }

    // ==, !=
    public static bool operator ==(Zespolona z1, Zespolona z2)
    {
        return (z1.Real == z2.Real && z1.Imag == z2.Imag);
    }
    public static bool operator !=(Zespolona z1, Zespolona z2) // można wykorzystać operator już zdefiniowany
    {
        // return !(z1.Real == z2.Real && z1.Imag == z2.Imag);
        return !(z1 == z2);
    }

    // Equals definiujemy aby działała tak jak ==
    public override bool Equals(object obj)
    {
        return this == (Zespolona)obj;
    }

    // dobre zdefiniowanie GetHashCode jest trudne
    // obiekty o "takiej samej zawartości" powinny miec hash code taki sam
    public override int GetHashCode()
    {
        return real.GetHashCode() ^ imag.GetHashCode(); // najprostrzy sposób
    }

    // mogę przeciążać wielokrotnie
    // Mogę porównywać Zespoloną z obiektami innych typów
    public static bool operator ==(Zespolona z1, double d)
    {
        return (z1.Real == d);
    }
    public static bool operator !=(Zespolona z1, double d)
    {
        return !(z1 == d);
    }

    // Mogę przeciążąć bardziej dziwne bez sensu
    public static double operator ==(Zespolona z1, int d) // NIE MUSI ZWRACAC bool
    {
        return z1.real - d;
    }
    public static double operator !=(Zespolona z1, int d) // NIE MUSI ZWRACAC bool
    {
        return d + z1.real;
    }


    //- jednoargumentowy, ~ jako sprzężenie, ! jako moduł,

    public static Zespolona operator ~(Zespolona z)
    {
        return new Zespolona(z.real, -z.imag);
    }
    public static Zespolona operator -(Zespolona z)
    {
        return new Zespolona(-z.real, -z.imag);
    }
    public static double operator !(Zespolona z) // ! może zwracać cokolwiek niekoniecznie bool
    {
        return Math.Sqrt(z.real * z.real + z.imag * z.imag);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Zespolona z = new Zespolona(1.3, 2.4);
        Console.WriteLine(z);
        Zespolona s = new Zespolona(1.0, 1.0);
        Console.WriteLine(s);
        Zespolona r = z + s;
        Console.WriteLine(r);
        r = z + 5.5;
        Console.WriteLine(r);
        r = 5.5 + z;
        Console.WriteLine(r);
        Console.WriteLine(z + 10);
        z += s; // od razu przeciążony +=
        Console.WriteLine(z);

        r = new Zespolona(1, 1);
        Console.WriteLine(s == z);
        Console.WriteLine(s != z);
        Console.WriteLine(s == r);
        Console.WriteLine(s.Equals(z));
        Console.WriteLine(s.Equals(r));
        Console.WriteLine("HashCode");
        Console.WriteLine(s.GetHashCode());
        Console.WriteLine(r.GetHashCode());
        Console.WriteLine(z.GetHashCode());
        Console.WriteLine("-------");

        Console.WriteLine(s == 1.0);
        Console.WriteLine(s == 1.5);

        if (z)
            Console.WriteLine("różne od 0");
        else
            Console.WriteLine("0");
        Zespolona z0 = new Zespolona(0, 0);
        if (z0)
            Console.WriteLine("różne od 0");
        else
            Console.WriteLine("0");

        Console.WriteLine(z == 9);
        Console.WriteLine(z != 9);

        Console.WriteLine(~z);
        Console.WriteLine(-z);
        Console.WriteLine(!s);

        Console.ReadKey();
    }
}
