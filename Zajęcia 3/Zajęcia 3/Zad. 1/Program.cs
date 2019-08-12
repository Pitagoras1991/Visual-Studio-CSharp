using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._1
{/*W klasie Tablica dopisz kolejno 
Konstruktor który może ustawić rozmiar tablicy.
Indeksery: pobieranie i-tego elementu, wstawianie i-tego elementu, 
metody: podawanie rozmiaru, wyszukiwanie elementu o podanej wartości, sumowanie elementów.*/

    class Tablica
    {

        private double[] tablica;

        public Tablica(int rozmiar)
        {
            this.tablica = new double[rozmiar];
        }

        public int Rozmiar
        { get { return tablica.Length; } }

        public double this[int i]
        {
            set { tablica[i] = value; }
            get { return tablica[i]; }
        }

        public void PodajRozmiar()
        { Console.WriteLine("Rozmiar: " + Rozmiar); }

        public bool CzyWystępuje(double a)
        {
            for (int i = 0; i < tablica.Length; i++)
            {
                if (tablica[i] == a) return true;

            }
            return false;
        }

        public double SumujTab()
        {
            double suma = 0;
            for (int i = 0; i < tablica.Length; i++)
            {
                suma += tablica[i];
            }
            return suma;
        }

        public void Wypisz()
        {
            for (int i = 0; i < tablica.Length; i++)
            {
                Console.Write("{0}  ", tablica[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tablica t = new Tablica(5);
            t.Wypisz();
            for (int i = 0; i < 5; i++)
            {
                t[i] = 10 * i;
            }
            t.Wypisz();
            t.PodajRozmiar();
            Console.WriteLine(t.CzyWystępuje(20));
            Console.WriteLine(t.SumujTab());
            Console.ReadKey();
        }
    }
}


