using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._1d
{
    public class Pracownik
    {
        string nazwisko;
        string stanowisko;
        public string Stanowisko { get { return stanowisko; } }
        public string Nazwisko { get { return nazwisko; } }
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

    // KILKA ENUMERATORÓW w firmie

    public class Firma : IEnumerable
    {
        string nazwa;
        private Pracownik[] pracownicy;
        public Firma(string nazwa, Pracownik[] pracownicy)
        {
            this.nazwa = nazwa;
            this.pracownicy = pracownicy;
        }

        public IEnumerable Odwrotny // upubliczniamy enumerator jako właściwość
        {
            get { return new OdwrotnyEnumerator(this); }
        }

        //od razu w jednej klasie implementujemy oba interfejsy
        class OdwrotnyEnumerator : IEnumerator, IEnumerable
        {
            Firma f;
            int indeks;

            public OdwrotnyEnumerator(Firma f)
            {
                this.f = f;
                indeks = f.pracownicy.Length;
            }

            public object Current
            {
                get { return f.pracownicy[indeks]; }
            }

            public bool MoveNext()
            {

                if (indeks > 0)
                {
                    indeks = indeks - 1;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                indeks = f.pracownicy.Length;
            }

            public IEnumerator GetEnumerator()
            {
                return this;
            }
        }

        // od razu w jednej klasie implementujemy oba interfejsy
        // ponieważ nie powołaliśmy instacji jak dla Odwrotny enumerator
        // to upubliczniamy klasę aby można było stworzyc instancję na zewnątrz
        public class PracownikEnumerator : IEnumerator, IEnumerable
        {
            Firma f;
            int indeks;
            public PracownikEnumerator(Firma f)
            {
                this.indeks = -1;
                this.f = f;
            }
            public object Current
            {
                get { return f.pracownicy[indeks]; }
            }

            public bool MoveNext()
            {
                if (indeks < f.pracownicy.Length - 1)
                {
                    indeks++;
                    return true;
                }
                else return false;
            }

            public void Reset()
            {
                indeks = -1;
            }

            public IEnumerator GetEnumerator()
            {
                return this;
            }
        }

        // ten enumerator będzie zwracany przez GetEnumerator
        class StringowyEnumerator : IEnumerator
        {
            Firma f;
            int indeks;
            public StringowyEnumerator(Firma f)
            {
                this.indeks = f.pracownicy.Length + 1;
                this.f = f;
            }
            public object Current
            {
                get
                {
                    if (indeks == f.pracownicy.Length) return f.nazwa;
                    else
                        return f.pracownicy[indeks].Nazwisko;
                }
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
                indeks = f.pracownicy.Length + 1;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return new StringowyEnumerator(this);
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

            foreach (String p in bud)
                Console.WriteLine(p);
            Console.WriteLine();

            //// mozna utworzyć istancję Enumeratora na zewnątrz jeśli jest publiczny
            foreach (Pracownik p in new Firma.PracownikEnumerator(bud))
                Console.WriteLine(p);
            Console.WriteLine();

            foreach (Pracownik p in bud.Odwrotny)
                Console.WriteLine(p);

            Console.ReadKey();
        }
    }
}
