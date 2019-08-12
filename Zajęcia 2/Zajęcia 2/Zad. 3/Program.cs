using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._3
{
    /*Napisać prostą klasę symulującą kalkulator (wystarczą cztery działania
     * i możliwość zapisu wyniku do pamięci). Dla klasy Kalkulator opracuj najpierw 
     * wersję z metodami niestatycznymi a następnie z metodami statycznymi. Czy Kalkulator 
     * jest lepszy z metodami statycznymi niż bez metod statycznych?*/


    class Kalkulator
    {
        double a;
        double b;
        double wynik;

        public Kalkulator(double a, double b)
        { this.a = a;
        this.b = b;
        }

        public double Dodaj()
        { return wynik = a + b; }

        public double Odejmij()
        { return wynik = a - b; }

        public double Pomnóż()
        { return wynik = a* b; }

        public double Podziel()
        { return wynik = a/ b; }

        public void WyświetlWynik(double wynik)
        { Console.WriteLine(wynik); }

        
    }

    static class KalkulatorStatyczny
    {
        static double a;
        static double b;
        static double wynik;

        static  KalkulatorStatyczny(double a, double b)
        { a = 50;
        b = 100;
        }

        public static double Dodaj()
        { return wynik; }

        public static double Odejmij()
        { return a - b; }

        public static double Pomnóż()
        { return a * b; }

        public static double Podziel()
        { return a / b; }

        public static void WyświetlWynik(double wynik)
        { Console.WriteLine(wynik); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Kalkulator k = new Kalkulator(5,7);
            k.WyświetlWynik(k.Dodaj());
           
        }
    }
}
