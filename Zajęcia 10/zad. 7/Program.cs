using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad._7
{/*Dla klasy Faktura zaimplementować interfejs IComparable operatory  >, <, >=, 
  * <= w sposób spójny. Ponadto zdefiniować operatory + jednoargumentowy suma wartości 
  * pozycji, + dwuargumentowy dodawanie pozycji o raz wersję z dodawaniem faktur.  
  * Zdefiniować także operatory ==, !=. Dodac następnie klasę pochodną Fakturadatowana 
  * i sprawdzić jak dla tej klasy działają zdefiniowane operatory.
}*/

    struct Pozycja
    {
        string nazwa;
        public int cena;

        public int Cena
        {
            get { return cena; }
        }

        public Pozycja(string nazwa, int cena)
        {
            this.nazwa = nazwa;
            this.cena = cena;
        }

        public override string ToString()
        {
            return nazwa + " cena: " + cena;
        }

        public static int operator +(Pozycja a, Pozycja b)
        { return a.Cena + b.Cena; }
    }

    class Faktura : IComparable
    {
        protected string nazwa;
        protected int numer;
        protected List<Pozycja> pozycje;

        public Faktura(string name, int id, List<Pozycja> pozycje)
        {
            this.nazwa = name;
            this.numer = id;
            this.pozycje = new List<Pozycja>();
        }

        public int CompareTo(object obj)
        {
            return nazwa.CompareTo(((Faktura)obj).nazwa);
        }

        public static bool operator <(Faktura s, Faktura t)
        {
            if (s.nazwa.CompareTo(t.nazwa) < 0)
                return true;
            else return false;
        }

        public static bool operator <=(Faktura s, Faktura t)
        {
            if (s.nazwa.CompareTo(t.nazwa) <= 0)
                return true;
            else return false;
        }

        public static bool operator >=(Faktura s, Faktura t)
        {
            if (s.nazwa.CompareTo(t.nazwa) >= 0)
                return true;
            else return false;
        }

        public static bool operator >(Faktura s, Faktura t)
        {
            if (s.nazwa.CompareTo(t.nazwa) > 0)
                return true;
            else return false;
        }

        public static Pozycja operator +(Faktura f)
        {
            return f.pozycje.Sum();
        }

        public override string ToString()
        {
            String s = nazwa + ":" + numer;
            foreach (Pozycja p in pozycje) s += "\n" + p;
            return s + "\n\n";
        }
    }

   class Program
        {
            static void Main(string[] args)
            {
                List<Pozycja> pozycje = new List<Pozycja>();
                pozycje.Add(new Pozycja("P1", 21));
                pozycje.Add(new Pozycja("P2", 37));
                pozycje.Add(new Pozycja("P3", 14));
                pozycje.Add(new Pozycja("P4", 88));

                Faktura FVAT = new Faktura ("Nowa", 1234, pozycje);
                Faktura FVATpopr = new Faktura ("Poprawiona", 1235, pozycje);

                Faktura[] tab = {FVAT, FVATpopr};
                Array.Sort(tab);

                Console.WriteLine(pozycje[1]);
                Console.WriteLine(pozycje[3]);
                Console.WriteLine(FVAT);
                Console.WriteLine(+FVAT);

                Console.WriteLine(FVAT<FVATpopr);

                foreach (Faktura f in tab)
                {Console.WriteLine(f);}

                Console.ReadKey();

            }
        }
    }

