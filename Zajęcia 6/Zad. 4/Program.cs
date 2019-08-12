using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._4
{/*Klasa String ma już zaimplementowany interfejs IComparable. Dla klasy String
  * zaimplementuj interfejs IComparer, który zapewni inne kryterium porządkowania
  * (długość napisu, odwrotna kolejność, po tekstach wspak). Napisz program ilustrujący 
  * sortowanie tablicy stringów na dwa różne sposoby.*/

    class PoDługości : IComparer
    {
        public int Compare(object x, object y)
        {
            if (((String)x).Length > ((String)y).Length) return 1;
            else if (((String)x).Length == ((String)y).Length) return 0;
            else return -1;
        }
    }

    class OdwrotnaKolejność : IComparer
    {
        public int Compare(object x, object y)
        {
            if (((String)x).CompareTo((String)y) == 1) return -1;
            else if (((String)x).CompareTo((string)y) == 0) return 0;
            else return 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] napisy = { "Ania", "Hania", "Mania", "Kasia", "Ziuta", "Genowefa" };
            for (int i = 0; i < napisy.Length; i++)
            {
                Console.Write(napisy[i]+ " ");
            }
            Array.Sort(napisy);

            for (int i = 0; i < napisy.Length; i++)
            {
                Console.Write(napisy[i] + " ");
            }
            Array.Sort(napisy, new PoDługości());
            for (int i = 0; i < napisy.Length; i++)
            {
                Console.Write(napisy[i]+ " ");
            }

            Array.Sort(napisy, new OdwrotnaKolejność());
            for (int i = 0; i < napisy.Length; i++)
            {
                Console.Write(napisy[i]+ " ");
            }
            Console.ReadKey();
        }
    }
}
