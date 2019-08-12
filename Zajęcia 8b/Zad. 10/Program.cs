using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._10
{/*Napisać własną klasę ogólną Kolejka (operacje Dodaj, Podejrzyj, Usuń, CzyPusta)
  * wykorzystując zawierania ogólnej kolekcji List<T>*/

    class Klient
    {
        string imię;
        string potrawa;

        public Klient(string im, string pot)
        {
            imię = im;
            potrawa = pot;
        }

        public override string ToString()
        {
            return "Imię " +imię + "Potrawa " +potrawa;
        }
    }

    class Kolejka<T>
    {
        public List<T> moja = new List<T>();

        public void Dodaj(T coś)
        {
            moja.Add(coś);
        }

        public void Podejrzyj(int i)
        {
            Console.WriteLine(moja[i]);
        }

        public void Usuń()
        {
            moja.RemoveAt(0);
        }

        public void CzyPusta()
        {
            Console.WriteLine(moja.Count == 0);
        }

        public void Wypisz()
        {
            for (int i = 0; i < moja.Count; i++)
            {
                Console.WriteLine(moja[i].ToString());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Kolejka<Klient> klienci = new Kolejka<Klient>();
            klienci.Dodaj(new Klient("Jan", "pizza"));
            klienci.Dodaj(new Klient("Anna", "pierogi"));
            klienci.Dodaj(new Klient("Ewelina", "tarta"));
            klienci.Podejrzyj(1);
            klienci.Usuń();
            klienci.Wypisz();
            klienci.CzyPusta();
            Console.ReadKey();
        }
    }
}