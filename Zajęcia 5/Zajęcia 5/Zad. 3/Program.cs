using System;
using System.IO;

//Opracować klasę z metodą, która wczytuje wyrazy z pliku 
//(należy zapytać o nazwę pliku), a następnie sortuje je alfabetycznie 
//(można korzystać z klasy Array). Posortowane wyrazy 
//należy zapisać do pliku wynikowego (zapytać o nazwę pliku).

class Zamiana
{
    public static void Porzadkowanie()
    {
        Console.WriteLine("Podaj nazwę pliku źródłowego");
        string path = Console.ReadLine();

        StreamReader plik = new StreamReader(path);
        string s = plik.ReadToEnd();

        char[] sep = { ' ', '\r', '\n' };
        string[] wyrazy = s.Split(sep, StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(wyrazy);

        Console.WriteLine("Podaj nazwę pliku docelowego");
        string path2 = Console.ReadLine();
        StreamWriter plik2 = new StreamWriter(path2);

        foreach (var item in wyrazy)
        {
            plik2.WriteLine(item);
        }
        plik.Close();
        plik2.Close();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Zamiana.Porzadkowanie();
        Console.ReadKey();
    }
}