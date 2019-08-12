using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad._1b
{
    public class Pracownik
    {
        string nazwisko;
        string stanowisko;
        public string Stanowisko { get { return stanowisko; } }
        public Pracownik(string n, string s)
        {
            nazwisko = n;
            stanowisko = s;
        }
        public override string ToString()
        {
            return string.Format("{0} ({1})", nazwisko, Stanowisko);
        }
    }


    public class Firma : IEnumerable
    {
        string nazwa;
        private Pracownik[] pracownicy;
        public Firma(string nazwa, Pracownik[] pracownicy)
        {
            this.nazwa = nazwa;
            this.pracownicy = pracownicy;
        }

        //od ostatniego do pierwszego korzystamy z yield
        public IEnumerator GetEnumerator()
        {
            for (int i = pracownicy.Length - 1; i >= 0; i--)
                yield return pracownicy[i];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pracownik[] pracownicy = { new Pracownik("Tarski", "murarz"),
                                     new Pracownik("Darski", "tynkarz"),
                                     new Pracownik("War", "glazurnik"),
                                     new Pracownik("Marks", "kierownik")
                                 };

            Firma bud = new Firma("Bud", pracownicy);

            foreach (Pracownik p in bud)
                Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}

