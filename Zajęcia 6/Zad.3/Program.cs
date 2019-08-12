using System;
using System.Collections;

//Dla klasy House zaimplementuj interfejs IComparable (według roku budowy a w przypadku tego samego roku po cenie). 
//Dodaj metodę ToString. 
//Dodaj także klasę implementującą IComparer do porównywania po powierzchni domu. 
//Napisz program ilustrujący sortujący tablicę domów.

class House : IComparable
{
    private decimal price;
    private int year;
    private double squareMeters;

    public House(decimal price, int year, double squareMeters)
    {
        this.price = price;
        this.year = year;
        this.squareMeters = squareMeters;
    }

    public double SquareMeters
    {
        get { return squareMeters; } // musi byc aby mozna było zdefiniować comparer
    }

    public override string ToString()
    {
        return String.Format("cena {0}, rok budowy {1}, powierzchnia {2}", price, year, squareMeters);
    }

    public int CompareTo(object obj)
    {
        if (year > ((House)obj).year) return 1;
        else if (year < ((House)obj).year) return -1;
        else
        {
            if (price > ((House)obj).price) return 1;
            else if (price < ((House)obj).price) return -1;
            return 0;
        }
    }
}

class PoPowierzchni : IComparer
{
    public int Compare(object x, object y)
    {
        if (((House)x).SquareMeters > ((House)y).SquareMeters) return 1;
        else if (((House)x).SquareMeters == ((House)y).SquareMeters) return 0;
        else return -1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        House h1 = new House(100000, 2007, 150);
        House h2 = new House(110000, 2011, 130);
        House h3 = new House(90000, 2000, 150);
        House h4 = new House(120000, 2011, 140);
        House h5 = new House(105000, 2000, 130);

        House[] domy = { h1, h2, h3, h4, h5 };
        for (int i = 0; i < domy.Length; i++)
            Console.WriteLine(domy[i]);

        Array.Sort(domy);
        Console.WriteLine();
        for (int i = 0; i < domy.Length; i++)
            Console.WriteLine(domy[i]);

        Array.Sort(domy, new PoPowierzchni());
        Console.WriteLine();
        for (int i = 0; i < domy.Length; i++)
            Console.WriteLine(domy[i]);

        Console.ReadKey();
    }
}
