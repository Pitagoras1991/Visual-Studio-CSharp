using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._3
{/*Dla klasy Pracownik, utwórz klasę GrupaPracowników zwierającą listę pracowników
  * (wykorzystaj ArrayList). Dla tej klasy zdefiniuj kilka iteratorów (zwykły, odwrotny;
  * iteracja ma być po kolekcji).*/

    public class Pracownik
    {
        string nazwisko;
        string stanowisko;

        public string Nazwisko { get { return nazwisko; } }
        public string Stanowisko { get { return stanowisko; } }

        public Pracownik(string n, string s)
        {
            nazwisko = n;
            stanowisko = s;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Nazwisko, Stanowisko);
        }
    }

    class GrupaPracowników: IEnumerable
    {
        static ArrayList nowa;
        public GrupaPracowników(ArrayList nowa)
        {
            nowa = new ArrayList();
        }

        public class OdwrotnyEnumerator : IEnumerator
        {
            int indeks;
            ArrayList moja;
            

            public OdwrotnyEnumerator(ArrayList m)
            {
                moja = m;
                indeks = m.Count;
            }

            public object Current
            {
                get { return moja[indeks]; }
            }

            public bool MoveNext()
            {
                if (indeks > 0)
                {
                    indeks++;
                    return true;
                }
                else return false;
            }

            public void Reset()
            { indeks = moja.Count; }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
