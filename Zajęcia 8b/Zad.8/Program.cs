using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._8
{/*Zadanie 8
Napisać program wczytujący z klawiatury zdania do kolekcji (jaką kolekcję wykorzystać?) 
  * a następnie odwracający poszczególne zdania (zakładamy spacje jako separator)  
  * oraz odwracający kolejność zdań (po każdym zdaniu wbijany jest enter) Wbicie
  * pustego zdania kończy wczytywanie.  Np. "Ala ma kota"  "Kot ma Alę"  na  "Alę ma Kot", 
  * " kota ma Ala". Na koniec należy wyświetlić wynik.*/

    class ListaZdan
    { 

       public bool CzyPuste = false;

        Stack<string> listazdań = new Stack<string>();

        public void Dodaj(Zdanie z)
        {
            if(z != null) listazdań.Push(z.zdanie);
            else CzyPuste = true;
        }

        public void PrzepiszOdwrotnie()
        {
            foreach (string z in listazdań)
            { Console.Write(z); }
        }

        class Zdanie
        {

            public Stack<char> zdanie = new Stack<char>();

            public void Zapisz()
            {
                string z = Console.ReadLine();

                for (int i = 0; i < z.Length; i++)
                {
                    zdanie.Push(z[i]);
                }
            }

            public void PrzepiszOdwrotnie()
            {
                foreach (char c in zdanie)
                { Console.Write(c); }
            }
        }
    }
    

   

    class Program
    {
        static void Main(string[] args)
        {
            ListaZdan MojaLista = new ListaZdan();
            while (MojaLista.CzyPuste == false)
            { Console.WriteLine("Wpisz zdanie");
            MojaLista.Dodaj(Console.ReadLine());
            MojaLista.PrzepiszOdwrotnie();
            }

            Console.ReadKey();
        }
    }
}
