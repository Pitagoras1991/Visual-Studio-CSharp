using System;

//Zadanie 5.
// Opracować klasę ZbiórZapisów do przechowywania zapisów. 
//W klasie ZbiórZapisów zdefiniuj klasy zagnieżdżone  
//Zapis oraz Licznik mają one być niewidoczne na zewnątrz. 
//Proszę napisać implementacje tych klas.

class ZbiórZapisów
{

    class Zapis // klasa wewnętrzna
    {
        string opis;
        int wartość;
        Zapis następny;
        public Zapis(string opis, int wartość)
        {
            this.opis = opis;
            this.wartość = wartość;
        }
        public void Wyświetl()
        {
            Zapis tmp = this;
            while (tmp != null)
            {
                Console.WriteLine(tmp.opis + " " + tmp.wartość);
                tmp = tmp.następny;
            }
        }
        public void Dodaj(Zapis nowy)
        {
            Zapis tmp = this;
            while (tmp.następny != null)
            {
                tmp = tmp.następny;
            }
            tmp.następny = nowy;
        }
    }

    class Licznik   // klasa wewnętrzna
    {
        int licznik = 0;

        public void Zwiększ()
        {
            licznik++;
        }
        public int Podaj()
        {
            return licznik;
        }
    }

    Licznik licznik = new Licznik();
    Zapis zapisy = null;

    public void Wyświetl()
    {
        Console.WriteLine("Zapisów jest:" + licznik.Podaj());
        if (zapisy != null)
        {
            zapisy.Wyświetl();
        }
    }
    public void Dodaj(string opis, int wartość)
    {
        if (zapisy == null)
        {
            zapisy = new Zapis(opis, wartość);
        }
        else
        {
            zapisy.Dodaj(new Zapis(opis, wartość));
        }
        licznik.Zwiększ();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ZbiórZapisów z = new ZbiórZapisów();
        z.Wyświetl();
        z.Dodaj("pierwszy", 1);
        z.Dodaj("drugi", 2);
        z.Wyświetl();
        z.Dodaj("trzeci", 3);
        z.Wyświetl();
        Console.ReadKey();
    }
}
