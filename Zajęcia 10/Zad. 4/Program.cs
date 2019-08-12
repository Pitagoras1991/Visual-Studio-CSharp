using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._4
{/*Napisać klasę Macierz do obsługi macierzy kwadratowych 2x2, przeciążyć dla niej operatory
  * ==, +, -, *. Jak określić dzielenie ? Dodać kilka przydatnych metod.*/

    class Macierz2x2
    {
        double a11, a12, a21, a22;

        public Macierz2x2()
            : this(0, 0, 0, 0)
        {
        }

        public Macierz2x2(double a, double b, double c, double d)
        {
            a11 = a;
            a12 = b;
            a21 = c;
            a22 = d;
        }

        public double this[int i, int j]
        {
            get
            {
                if (i == 0 && j == 0) return a11;
                if (i == 0 && j == 1) return a12;
                if (i == 1 && j == 0) return a21;
                if (i == 1 && j == 1) return a22;
                return Double.NaN;
            }
        }

        //toString
        public override string ToString()
        {
            return "|\t" + a11 + "\t" + a12 + "\t|\n" +
                   "|\t" + a21 + "\t" + a22 + "\t|\n";
        }

        public static Macierz2x2 operator +(Macierz2x2 A, Macierz2x2 B)
        { return new Macierz2x2(A.a11 + B.a11, A.a12 + B.a12, A.a21+B.a21, A.a22+B.a22); }

        public static Macierz2x2 operator -(Macierz2x2 A, Macierz2x2 B)
        { return new Macierz2x2(A.a11 - B.a11, A.a12 - B.a12, A.a21 - B.a21, A.a22 - B.a22); }

        public static Macierz2x2 operator *(Macierz2x2 A, Macierz2x2 B)
        { return new Macierz2x2(A.a11 * B.a11 + A.a12*B.a21, A.a11 * B.a21 + A.a12* B.a22,
            A.a21 * B.a11 + A.a22* B.a21, A.a21 * B.a12 + A.a22 * B.a22); }

        public static bool operator ==(Macierz2x2 A, Macierz2x2 B)
        {
            if (Macierz2x2.ReferenceEquals(A, null) || Macierz2x2.ReferenceEquals(B, null)) return false;
            else return (A.a11 == B.a11 && A.a12 == B.a12 && A.a21 == B.a21 && A.a22 == B.a22);
        }

        public static bool operator !=(Macierz2x2 A, Macierz2x2 B)
        { return !(A==B);}

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Macierz2x2) return this == (Macierz2x2)obj;
            else return false;
        }

        public override int GetHashCode()
        {
            return a11.GetHashCode();
        }


        public static double operator ~(Macierz2x2 A) //Wyznacznik macierzy
        { return (A.a11*A.a22 - A.a12*A.a21); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Macierz2x2 A = new Macierz2x2(1, 1, 1, 1);
            Macierz2x2 B = new Macierz2x2(1, 2, 2, 1);
            Console.WriteLine(A);
            Console.WriteLine(B);
            Console.WriteLine(A+B);
            Console.WriteLine(B-A);
            Console.WriteLine(A*B);
            Console.WriteLine(~A);
            Console.WriteLine(~B);
            Console.WriteLine(A==B);
            Console.ReadKey();
        }
    }
}
