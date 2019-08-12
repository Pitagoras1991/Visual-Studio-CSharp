using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._5
{/*Napisać własną klasę SuperString, podobną do String (wykorzystać zawieranie - tablicę char
  * albo StringBuilder albo bezpośrednio string). Dla tej klasy zdefiniować przeciążone 
  * operatory, operatory <;<=; >;>=, operator ! odwracający napis, operator >> skracający
  * napis i << dopisujący spacje. Dodać operatory konwersji (jawnej czy niejawnej?) między 
  * SuperString a String*/

    class SuperString
    {
        string wyraz;
       

        public SuperString(string s)
        {
            wyraz = s;
        }

        public static bool operator <= (SuperString s1, SuperString s2)
        { 
 
            for (int i = 0; i < Math.Min(s1.wyraz.Length, s2.wyraz.Length); i++)
			{
                if (s1.wyraz[i] < s2.wyraz[i]) return true;
                if (s1.wyraz[i] > s2.wyraz[i]) return false;
			}
            return true;
            
        }

        public static bool operator >=(SuperString s1, SuperString s2)
        {

            for (int i = 0; i < Math.Min(s1.wyraz.Length, s2.wyraz.Length); i++)
            {
                if (s1.wyraz[i] < s2.wyraz[i]) return false;
                if (s1.wyraz[i] > s2.wyraz[i]) return true;
            }
            return true;
        }

     
    }

    class Program
    {
        static void Main(string[] args)
        {
                SuperString s1 = new SuperString("Karol");
                SuperString s2 = new SuperString("Karolina");
                SuperString s3 = new SuperString("Karakan");
                Console.WriteLine(s1<=s2);
                Console.WriteLine(s3<=s1);
                Console.WriteLine(s1>=s2);
                Console.WriteLine(s3>=s1);
                Console.ReadKey();
        }
    }
}
