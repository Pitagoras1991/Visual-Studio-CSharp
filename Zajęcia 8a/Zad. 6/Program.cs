using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._6
{/*Zdefiniuj klasę ogólną Sumator z metodą do sumowania dowolnych tablic których elementy
  * implementują interfejs IDodawalny. Utwórz kilka klas implementujących ten interfejs i
  * zilustruj działanie klasy Sumator.*/

    interface IDodawalny<T>
    {
        T Dodaj(T b)
        {return object+b;}
    }


    class Ogólna<T> : IDodawalny<int>
    {
        public T x;
        public Ogólna(T x)
        {this.x = x;}

        public T Dodaj(T b)
        { return x.Dodaj( }
    }

    class Sumator<T> : IDodawalny<T>
    {
        public T Sumowanie(T[] tab)
        {
            T x; 
            Ogólna<T> suma = new Ogólna<T>(x);

            for (int i = 0; i < tab.Length; i++)
            {
                suma = suma.Dodaj(tab[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PunktWR1 p = new PunktWR1(1);
            PunktWR1 q = new PunktWR1(2);
            IntNiestandardowy i1 = new IntNiestandardowy(5);
            Console.WriteLine(p.Dodaj(10));
            Console.WriteLine(p.Dodaj(q.x));
            Console.WriteLine(i1.Dodaj(17));
            Console.ReadKey();

        }
    }
}
