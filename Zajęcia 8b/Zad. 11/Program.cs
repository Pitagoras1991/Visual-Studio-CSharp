using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._11
{/*Napisać własną klasę ogólną StosLimitowany<T> gdzie T IComparable<T>, 
  * wykorzystując dziedziczenie ogólnej kolekcji Stack<T>. Jaki jest problem
  * implementacji z dziedziczeniem?*/

    class Stos<T>
    {
        public List<T> moja = new List<T>();

        public void Połóż(T coś)
        {
            moja.Add(coś);
        }

        public void Podejrzyj(int i)
        {
            Console.WriteLine(moja[i]);
        }

        public void Zdejmij()
        {
            moja.RemoveAt(moja.Count-1);
        }

        public void CzyPusty()
        {
            Console.WriteLine(moja.Count == 0);
        }

        public void Wypisz()
        {
            for (int i = 0; i < moja.Count; i++)
            {
                Console.WriteLine(moja[i]);
            }
        }
    }


    class StosLimitowany<T> : Stos<T>
    {
        int limit;

        public StosLimitowany<T> mój = new StosLimitowany<T>(); //problem implementacji - nie można dziedziczyć po czymś, czego polem jest lista
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stos<string> książki = new Stos<string>();
            książki.Połóż("Pan Tadeusz");
            książki.Połóż("Balladyna");
            książki.Połóż("Plastusiowy Pamiętnik");
            książki.Podejrzyj(2);
            książki.Zdejmij();
            książki.Wypisz();
            książki.CzyPusty();
            Console.ReadKey();
        }
    }
}
