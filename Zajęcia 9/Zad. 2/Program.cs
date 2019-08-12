using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._2
{/*Zaimplementować interfejs IEnumerable<T> dla klasy Firma<T> napisać program 
  * ilustrujący wykorzystujący klasy Pracownik, Osoba itp.*/

    public class Osoba
    {
        string nazwisko;
        string imie;

        public string Nazwisko { get { return nazwisko; } }
        public string Imie { get { return imie; } }

        public Osoba(string n, string s)
        {
            nazwisko = n;
            imie = s;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Nazwisko, Imie);
        }
    }

    public class Pies
    {
        string imię;
        string rasa;

        public string Imię { get { return imię; } }
        public string Rasa { get { return rasa; } }

        public Pies(string i, string r)
        {
            imię = i;
            rasa = r;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", imię, rasa);
        }
    }

    public class Firma<T> : IEnumerable<T>
    {
        string nazwa;
        private T[] pracownicy;

        public Firma(string nazwa, T[] pracownicy) 
        { this.nazwa = nazwa;
          this.pracownicy = pracownicy;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)pracownicy).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)pracownicy).GetEnumerator();
        }

       
    }

    class Program
    {
        static void Main(string[] args)
        {
            Osoba[] kadraludzka = {new Osoba("Karol", "Papież"), 
                                   new Osoba ("Indira", "Premier"), 
                                   new Osoba ("Tadeusz", "Dyrektor"),
                                   new Osoba ("Klaudiusz", "Zamiatacz"), 
                                   new Osoba ("Marcin", "Inżynier")};

            Pies[] kadrapsia = {new Pies("Azor", "Labrador"),
                                new Pies("Niuchacz", "Wilczur"),
                                new Pies ("Zuska", "Kundel"),
                               new Pies("Jesper", "York"),
                                new Pies ("Kama", "Canne Corso")};

            Firma<Osoba> firmaL = new Firma<Osoba>("FirmaL", kadraludzka);
            Firma<Pies> firmaP = new Firma<Pies>("FirmaP", kadrapsia);

            foreach (Osoba o in firmaL)
            {
                Console.WriteLine(o);
            }

            foreach (Pies p in firmaP)
            {
                Console.WriteLine(p);
            }

            Console.ReadKey();
        }
    }
}
