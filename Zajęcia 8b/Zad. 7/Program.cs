using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._7
{/*Zadanie 7
Napisać klasę na bazie kolekcji (jaką kolekcję wykorzystać?) wypisującą częstość
  * (histogram) wprowadzonych z klawiatury liczb dodatnich (0 kończy wczytywanie). */

    class Lista
    {
        public bool CzyZero = false;
        public Lista()
        {}

        public List<int> liczby = new List<int>();

        public void Dodaj()
        {

                 int a = 0;
                 Console.WriteLine("Proszę wpisać liczbę dodatnią");
                 a = Convert.ToInt32(Console.ReadLine());
                 if (a > 0)
                 {
                     liczby.Add(a);
                 }
                 else if (a == 0) {
                     CzyZero = true;
                     Console.WriteLine ("Koniec dodawania liczb"); }
                 else throw new ApplicationException("Liczba niedodatnia");

            
        }

        public int częstość (int wartosc)
        {
            int licznik=0;

            for (int i = 0; i < liczby.Count; i++)
			{
                if (liczby[i] == wartosc)
                { licznik++; }
                else { }
			}

        return licznik;
        }

        public void WypiszH()
        {
           
                for (int i = 0; i < liczby.Count; i++)
                {
                    if (liczby.Contains(liczby[i]) == true)
                    {
                        Console.WriteLine("Liczba {0} wystąpiła dotychczas {1} razy", liczby[i], częstość(liczby[i]));
                    }
                }
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lista MojaLista = new Lista();
            while (MojaLista.CzyZero == false)
            { MojaLista.Dodaj();
              MojaLista.WypiszH();
            }
            Console.ReadKey();
        }
    }
}
