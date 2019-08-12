using System;

//Zadanie 3. 
// Opracować klasę Operacje która ma metody do obliczania silni, 
// pierwiastka kwadratowego, podnoszenia do potęgi trzeciej itp.
// Na liczbach typu int (pierwiastek zaokrąglamy do liczby całkowitej).
// Metody powinny zwracać rozszerzony typ int (null jeśli operacja 
// nie jest wykonalna, przekracza zakres itp.). 

class Operacje
{
    public static int? Silnia(int n)
    {
        if (n > 12)
        {
            return null;
        }

        int s = 1;

        for (int i = 1; i <= n; i++)
        {
            s *= i;
        }

        return s;
    }

    public static double? Pierwiastek(double n)
    {
        if (n > 0)
        {
            return Math.Sqrt(n);
        }
        else
        {
            return null;
        }
    }

    public static int? Pierwiastek(int n) // ten obcina
    {
        if (n > 0)
        {
            return (int)Math.Sqrt(n);
        }
        else
        {
            return null;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        for (int i = 1; i < 15; i++)
        {
            double? x = Operacje.Silnia(i);
            if (x.HasValue)
            {
                Console.WriteLine(x.Value);
            }
            else
            {
                Console.WriteLine("Poza zakresem");
            }
        }

        double? y = Operacje.Pierwiastek(10.0);

        if (y.HasValue) Console.WriteLine(y.Value);
        else Console.WriteLine("Nie mozna pierwiastkowac");

        y = Operacje.Pierwiastek(-10.0);

        if (y.HasValue) Console.WriteLine(y.Value);
        else Console.WriteLine("Nie mozna pierwiastkowac");

        int? z = Operacje.Pierwiastek(10);

        if (z.HasValue) Console.WriteLine(z.Value);
        else Console.WriteLine("Nie mozna pierwiastkowac");

        z = Operacje.Pierwiastek(-10);

        if (z.HasValue) Console.WriteLine(z.Value);
        else Console.WriteLine("Nie mozna pierwiastkowac");

        Console.ReadKey();
    }
}
