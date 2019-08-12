using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._2
{/*Napisać strukturę Wektor do obsługi wektorów 3 wymiarowych. Dodać operatory -
  * jednoargumentowy, + -, * i / do mnożenia i dzielenia przez skalar , == i != (nadpisać
  * też Equals i GetHashCode), ~ do wyznaczania modułu, ! do normowania wektora, ^ iloczyn
  * skalarny, * iloczyn wektorowy, operatory > < (porównywanie długości), true i false oraz
  * >> <<, te ostatnie mają dodawać lub odejmować wartość od każdej współrzędnej.
 (wsk. rozpocznij od kodów z wykładu)*/

    struct Wektor
    {
        double a, b, c;

        public Wektor(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override string ToString()
        {
            return string.Format("Wektor: [{0},{1},{2}]",a,b,c);
        }

        public static  Wektor operator -(Wektor w1)
        { return new Wektor(-w1.a, -w1.b, -w1.c);}

        public static Wektor operator +(Wektor w1, Wektor w2)
        { return new Wektor(w1.a + w2.a, w1.b + w2.b, w1.c + w2.c); }

        public static Wektor operator -(Wektor w1, Wektor w2)
        { return new Wektor(w1.a - w2.a, w1.b - w2.b, w1.c - w2.c); }

        public static Wektor operator *(Wektor w1, double n)
        { return new Wektor(w1.a * n, w1.b * n, w1.c *n); }

        public static Wektor operator /(Wektor w1, double n)
        { return new Wektor(w1.a / n, w1.b / n, w1.c / n); }

        public static bool operator ==(Wektor w1, Wektor w2)
        { return (w1.a == w2.a && w1.b == w2.b && w1.c == w2.c); }

        public static bool operator !=(Wektor w1, Wektor w2)
        { return !(w1==w2); }

        public override bool Equals(object obj)
        {
            return this ==(Wektor)obj;
        }

        public override int GetHashCode()
        {
            return a.GetHashCode() ^ b.GetHashCode() ^ c.GetHashCode();
        }

        public static double operator ~(Wektor w1)
        { return Math.Sqrt(w1.a*w1.a + w1.b*w1.b + w1.c*w1.c); }

        public static double operator ^(Wektor w1, Wektor w2)
        { return (w1.a * w2.a + w1.b * w2.b + w1.c * w2.c); }

        public static bool operator >(Wektor w1, Wektor w2)
        { return (~w1 > ~w2); }

        public static bool operator <(Wektor w1, Wektor w2)
        { return (~w1 < ~w2); }

        /*public static Wektor operator >>(Wektor w1, double n)
        { return new Wektor(w1.a + n, w1.b + n, w1.c + n);}

        public static Wektor operator <<(Wektor w1, double n)
        { return new Wektor(w1.a - n, w1.b - n, w1.c - n); }*/
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wektor p = new Wektor(1, 1, 1);
            Console.WriteLine(p);
            Wektor q = new Wektor(2, 3, 5);
            Console.WriteLine(q);
            Wektor r = p + q;
            Console.WriteLine(r);
            r = p - q;
            Console.WriteLine(r);
            r = p * 5;
            Console.WriteLine(r);
            r = q / 3;
            Console.WriteLine(r);
            r = -p;
            Console.WriteLine(r);
            Console.WriteLine(p==q);
            Console.WriteLine(p!=q);
            Console.WriteLine("GetHashCode");
            Console.WriteLine(p.GetHashCode());
            Console.WriteLine("--------");
            Console.WriteLine(~q);
            Console.WriteLine(p^q);
            //Console.WriteLine(p>>1);
            //Console.WriteLine(q<<1);
            Console.ReadKey();
        }
    }
}
