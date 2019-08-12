using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad._9
{/*Napisać własną klasę ogólną Stos (operacje Połóż, Podejrzyj, Zdejmij, CzyPusty) 
  * wykorzystując zawierania ogólnej kolekcji List<T>.*/

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
