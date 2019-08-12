using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparer
{
    class Student : IComparable<Student>
    {
        string imię;
        string nazwisko;
        int numerIndeksu;
        int wiek;

        public Student(string im, string na, int w, int ind)
        {
            imię = im;
            nazwisko = na;
            wiek = w;
            numerIndeksu = ind;
        }

        public string Imię
        {
            get { return imię; }
        }
        public string Nazwisko
        {
            get { return nazwisko; }
        }
        public int Wiek
        {
            get { return wiek; }
        }
        public int NumerIndeksu
        {
            get { return numerIndeksu; }
        }

        public override string ToString()
        {
            return String.Format("student {0} {1} lat {2} indeks numer:{3}", imię, nazwisko, wiek, numerIndeksu);
        }

        public int CompareTo(Student other)
        {
            return nazwisko.CompareTo(other.nazwisko);
        }
    }

    // te komparatory są osobnymi klasami
    // muszą mieć dostęp do pól które są porównywane

    class PoWieku : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Wiek.CompareTo(y.Wiek);
        }
    }

    class PoIndeksie : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.NumerIndeksu - y.NumerIndeksu;
        }
    }

    class PoImieniu : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Imię.CompareTo(y.Imię);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] studenci = { 
                                     new Student("Jan", "Eski", 20, 12345),
                                     new Student("Alicja", "Reks", 21, 22345),
                                     new Student("Anna", "Bols", 20, 32345),
                                     new Student("Adam", "Reks", 22, 92345),
                                     new Student("Marian", "Eski", 21, 62345),
                                 };

            foreach (Student s in studenci)
                Console.WriteLine(s);
            Console.WriteLine();

            Array.Sort(studenci);
            foreach (Student s in studenci)
                Console.WriteLine(s);
            Console.WriteLine();

            Array.Sort(studenci, new PoWieku());
            foreach (Student s in studenci)
                Console.WriteLine(s);
            Console.WriteLine();

            Array.Sort(studenci, new PoIndeksie());
            foreach (Student s in studenci)
                Console.WriteLine(s);
            Console.WriteLine();

            Array.Sort(studenci, new PoImieniu());
            foreach (Student s in studenci)
                Console.WriteLine(s);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
