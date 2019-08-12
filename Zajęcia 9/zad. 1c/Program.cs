using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad._1c
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
        // klasa enumeratora samodzielnie zaimplementowana
        class MojEnumerator : IEnumerator
        {
            Firma f;
            int indeks;
            public MojEnumerator(Firma f)
            {
                this.indeks = f.pracownicy.Length;
                this.f = f;
            }
            public object Current
            {
                get { return f.pracownicy[indeks]; }
            }

            public bool MoveNext()
            {
                if (indeks > 0)
                {
                    indeks--;
                    return true;
                }
                else return false;

            }

            public void Reset()
            {
                indeks = f.pracownicy.Length;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return new MojEnumerator(this);// tworzymy enumerator
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
