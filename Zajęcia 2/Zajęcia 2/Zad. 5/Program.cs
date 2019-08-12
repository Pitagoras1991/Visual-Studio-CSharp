using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._5
{
    /*Opracować metodę rozszerzającą (rozszerzoną) dla typu int służącą do zamiany liczby
     * z systemu dziesiętnego na  zapis (string) w innym systemie o podstawie < 10.
*/

    static class RozszerzenieInt
    {
        public static string ZamianaNaInny(this int x, int n)
        {
            string s = " ";
            decimal tmp;
            while (x > 0)
            {
                tmp = x - n * Math.Floor((decimal)x / n);
                s += tmp.ToString();
                x = (int)Math.Floor((decimal)x / n);
            }
            return s;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            int i = 15;
            Console.WriteLine(i.ZamianaNaInny(2));
            Console.WriteLine(i.ZamianaNaInny(3));
            Console.ReadKey();
        }
    }
}
