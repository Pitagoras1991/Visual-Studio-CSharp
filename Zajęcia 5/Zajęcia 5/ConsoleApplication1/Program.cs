using System;
using System.IO;

//Automat do rozpoznawania monet generuje plik tekstowy, 
//który zawiera ciąg znaków opisujących poszczególne monety 
//(bez żadnych znaków rozdzielających):

//moneta znak
//1 gr  - a
//2 gr  - b
//5 gr  - c
//10 gr - d
//20 gr - e
//50 gr - f
//1 zł  - A
//2 zł  - B
//5 zł  - C

//Opracować klasę z metodą która wczytuje wszystkie znaki z takiego 
//pliku i oblicza łączną kwotę złotych i groszy rozpoznanych przez 
//automat .

class Automat
{
    // BinaryReader i PeekChar do sprawdzania końca czytania

    public static decimal Oblicz(string path)
    {
        decimal suma = 0.0M;

        BinaryReader br = new BinaryReader(new FileStream(path, FileMode.Open));

        while (br.PeekChar() != -1)
        {
            char c = br.ReadChar();

            switch (c)
            {
                case 'a': suma += 0.01m; break;
                case 'b': suma += 0.02m; break;
                case 'c': suma += 0.05m; break;
                case 'd': suma += 0.1m; break;
                case 'e': suma += 0.2m; break;
                case 'f': suma += 0.5m; break;
                case 'A': suma += 1m; break;
                case 'B': suma += 2m; break;
                case 'C': suma += 5m; break;

                default: break;
            }
        }

        br.Close();
        return suma;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Automat.Oblicz("..\\..\\..\\dane.txt"));
        Console.ReadKey();
    }
}
