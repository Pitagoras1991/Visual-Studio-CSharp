using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._3
{
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


    //Napisać klasę Piksel do obsługi punktu o współrzędnych całkowitych (int) na płaszczyźnie. 
    //Napisz przeciążony operator  ==, != oraz metodę Equals. 
    //Operatory ++, --, true, false oraz & i |.
    //W klasie Piksel dodaj operator konwertujący Piksel na Zespolona i odwrotnie.

    class Piksel
    {
        int x, y;

        public Piksel()
        {
            x = y = 0;
        }
        public Piksel(int i, int j)
        {
            x = i;
            y = j;
        }
        public override string ToString()
        {
            return "<" + x + ", " + y + ">";
        }

        // ==, !=, Equals
        public static bool operator ==(Piksel p, Piksel q)
        {
            // dla klas powinnismy sprawdzić czy nie null
            // ponieważ właśnie przeciążamy == musimu użyc ReferenceEquals
            if (Piksel.ReferenceEquals(p, null) || Piksel.ReferenceEquals(q, null)) return false;
            return (p.x == q.x && p.y == q.y);
        }
        public static bool operator !=(Piksel p, Piksel q)
        {
            return !(p == q);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Piksel)
                return this == (Piksel)obj;
            else return false;
        }

        // konwersja
        public static implicit operator Zespolona(Piksel p)
        {
            return new Zespolona(p.x, p.y);
        }
        public static explicit operator Piksel(Zespolona z)
        {
            return new Piksel((int)z.Real, (int)z.Imag);
        }

        // ++ , --
        public static Piksel operator ++(Piksel p) // MUSI zwracac Piksel
        {
            return new Piksel(p.x + 1, p.y + 1);
        }
        public static Piksel operator --(Piksel p) // MUSI zwracac Piksel
        {
            return new Piksel(--p.x, --p.y);
        }

        // & i |
        public static Piksel operator &(Piksel p, Piksel q)
        {
            return new Piksel(Math.Max(p.x, q.x), Math.Max(p.y, q.y));
        }

        public static Piksel operator |(Piksel p, Piksel q)
        {
            return new Piksel(Math.Min(p.x, q.x), Math.Min(p.y, q.y));
        }
        // Mogę przeciążać wielokrotnie i zwracać rozmaite typy
        public static bool operator |(Piksel p, int n)
        {
            return p.x == n;
        }

        // true i false 
        // aby sprawdzić &&
        public static bool operator false(Piksel p)
        {
            return p.x == 0 && p.y == 0;
        }
        public static bool operator true(Piksel p)
        {
            return p.x != 0 || p.y != 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Piksel m = new Piksel(1, 2);
            Piksel n = new Piksel(1, 1);
            Piksel p = new Piksel(1, 2);

            Console.WriteLine(p);
            Zespolona z = p;
            Console.WriteLine(z);
            Piksel r = (Piksel)z;
            Console.WriteLine(r);

            Console.WriteLine();
            Console.WriteLine(m == n);
            Console.WriteLine(m == p);
            Console.WriteLine(m != n);
            Console.WriteLine(m != p);
            Console.WriteLine(m == null);
            Console.WriteLine(m.Equals(n));
            Console.WriteLine(m.Equals(p));
            Console.WriteLine(m.Equals(z)); // z Zespolona

            Console.WriteLine();
            Piksel q = ++r;
            Console.WriteLine(q);
            Console.WriteLine(r); //także r się zmieniło tak jak dla int!
            p++;
            Console.WriteLine(p);
            --p;
            Console.WriteLine(p);

            Console.WriteLine();
            Console.WriteLine(m & n);
            Console.WriteLine(m | n);
            Console.WriteLine(m | 2);
            // ponieważ mamy true i false oraz & to automatycznie zdefiniowany jest && i ||
            Console.WriteLine(m && n);
            Console.WriteLine(m || n);


            Console.ReadKey();
        }
    }
}
