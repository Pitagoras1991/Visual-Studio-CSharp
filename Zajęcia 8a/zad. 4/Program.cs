using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad._4
{
    class Student: IComparable<Student>
    {
        string imię;
        string nazwisko;
        int wiek;
        int indeks;

        public Student(string im, string naz, int wie, int ind)
        {
            imię = im;
            nazwisko = naz;
            wiek = wie;
            indeks = ind;
        }

        public override string ToString()
        {
            return string.Format("Student {0} {1} wiek {2} nr indeksu {3}", imię, nazwisko, wiek, indeks);
        }

        public int CompareTo(Student other)
        {
            return nazwisko.CompareTo(other.nazwisko);
        }

        public class PoWieku : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return x.wiek.CompareTo(y.wiek);
            }
        }

        public class PoIndeksie : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return x.indeks.CompareTo(y.indeks);
            }
        }

        public class PoImieniu : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return x.imię.CompareTo(y.imię);
            }
        }
    }

    /*Napisać metodę ogólną obliczającą maksymalną wartość w tablicy dowolnego typu 
     * (dla którego mamy zdefiniowane porównywanie elementów przez IComparable). 
     * Dodatkowo proszę napisać metodę ogólną obliczającą maksymalną wartość w tablicy 
     * dowolnego typu z parametrem IComparer. Zilustrować program przykładami (int, string, 
     * Student).*/

    class RowneParzyscie : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (x % 2 == 0 &&  y % 2 ==0) return 0; // obie parzyste
        else if (x % 2 == 0 &&  y % 2 !=0  || x % 2 != 0 &&  y % 2 ==0) return 1; // jedna nieparzysta
        else return -1;
    }
}

    class Program
    {
        static T ObliczMax<T>(T[] tab) where T : IComparable<T>
        {
            T max = tab[0];

            for (int i = 0; i < tab.Length; i++)
            {
                

                if (tab[i].CompareTo(max) > 0)
                {
                    max = tab[i];
                    i++;
                }
                else i++;
            }

            return max;
        }

        static T ObliczMax<T>(T[] tab, IComparer<T> cmp) 
        {
            T max = tab[0];

            for (int i = 0; i < tab.Length; i++)
            {


                if (cmp.Compare(tab[i], max) > 0)
                {
                    max = tab[i];
                    i++;
                }
                else i++;
            }

            return max;
        }

        static void Main(string[] args)
        {

            Student[] studenci = { 
                                     new Student("Jan", "Eski", 20, 12345),
                                     new Student("Alicja", "Reks", 21, 22345),
                                     new Student("Anna", "Bols", 20, 32345),
                                     new Student("Adam", "Maski", 22, 22312),
                                     new Student("Anna", "Maski", 19, 82312), 
                                     new Student("Jolanta", "Kasai", 22, 72312),
                                     new Student("Adam", "Reks", 22, 92345),
                                     new Student("Marian", "Eski", 21, 62345),
                                 };
            int[] tab = { 1, 2, 4, 3, 2, 3, 5 };

        Console.WriteLine(ObliczMax(studenci));
        Console.WriteLine(ObliczMax(tab));
       Console.WriteLine(ObliczMax(tab, new RowneParzyscie()));
        Console.ReadKey();
    
}
        }
    }

