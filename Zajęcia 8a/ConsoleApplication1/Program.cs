using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Student : IComparable<Student>

    {
        string imię;
        string nazwisko;
        int wiek;
        int indeks;

        public Student(string imię, string nazwisko, int wiek, int indeks)
        {
            this.imię = imię;
            this.nazwisko = nazwisko;
            this.wiek = wiek;
            this.indeks = indeks;
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
        public int Indeks
        {
            get { return indeks; }
        }

        public override string ToString()
        {
            return String.Format("student {0} {1} lat {2} indeks numer:{3}", imię, nazwisko, wiek, indeks);
        }

        public int CompareTo(Student other)
        { 
            return nazwisko.CompareTo(other.nazwisko);
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

            Console.ReadKey();
        }
    }
}
