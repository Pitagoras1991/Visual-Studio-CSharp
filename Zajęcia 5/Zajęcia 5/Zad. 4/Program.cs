using System;
using System.IO;
using System.Linq;

namespace Zad._4
{/*Zadanie 4 (dom)
Napisz klasę z metoda, która poprosi użytkownika o podanie nazwy pliku tekstowego. 
  * Następnie metoda sprawdzi czy plik istnieje, wyświetlając komunikat o błędzie gdy
  * pliku nie ma w podanej lokalizacji. Plik zostanie otwarty i jego zawartość zostanie
  * skopiowana do nowego pliku (którego nazwę pod użytkownik), przy czym każdy znak będący
  * literą zostanie zamieniony na literę wielką.*/

    class Sprawdzenie
    {
        public static void Powiększenie()
        {
            Console.WriteLine("Podaj nazwę ścieżki źródłowej");
            string path = Console.ReadLine();

            StreamReader sr = new StreamReader(path);
            string s = sr.ReadToEnd();

           

            Console.WriteLine("Podaj nazwę pliku docelowego");
            string path2 = Console.ReadLine();

            StreamWriter sw = new StreamWriter(path2);

            sw.WriteLine(s.ToUpper());
            sr.Close();
            sw.Close();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Sprawdzenie.Powiększenie();
            Console.ReadKey();
        }
    }
}
