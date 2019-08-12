using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._7
{ /*Zadanie 7
W klasie Program napisać metodę wypisującą na ekran wynik dzielenia dwóch liczb typu double
double divide(double a, double b)
Metoda ma zgłaszać wyjątek w przypadku dzielenia przez zero.*/

    class Program
    {
        static void Dzielenie(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            else Console.WriteLine(a/b);
        }

        static void Main(string[] args)
        {
            Dzielenie(5, 1);
            Dzielenie(15, 3);
            Console.ReadKey();
        }
    }
}
