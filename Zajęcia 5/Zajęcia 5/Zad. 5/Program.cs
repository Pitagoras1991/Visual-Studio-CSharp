using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zad._5
{ /*Zadanie 5
Opracować klasę Baza do prowadzenia spisu komputerów (max. 20 komputerów przechowywanych w 
   * tablicy). Każdy komputer opisany jest za pomocą klasy zawierającej nazwę ,producenta, cenę,
   * podstawowe parametry (takie jak RAM,  wielkość dysku).  Klasa Baza realizuje  polecenia
   * umożliwiające:
C : wczytanie liczby komputerów  i tablicy obiektów opisujących komputery z pliku dyskowego
   * (należy zapytać o nazwę pliku),
N :  wczytanie danych opisujących nowy komputer (jego typ, parametry itp.)  i wprowadzenie ich 
   * do kolejnej pozycji  tablicy obiektów,
W : wyświetlanie informacji o wszystkich komputerach,
Z : zapis liczby komputerów i tabeli obiektów do pliku dyskowego (zapytać o nazwę pliku),
Q : zakończenie programu.*/

    class Komputer
    { string nazwa, producent;
      double cena;
      double Ram;
      double wielkośćDysku;

        public string Nazwa
        {get{return nazwa;} set{nazwa = value;}}

        public string Producent
        { get { return producent; } }

        public double Cena
        { get { return cena; } }

        public double RAM
        { get { return Ram; } }

        public double WielkośćDysku
        { get { return wielkośćDysku; } }

        public Komputer(string nazwa, string producent, double cena, double Ram, double wielkośćDysku)
        { this.nazwa = nazwa;
        this.producent = producent;
        this.cena = cena;
        this.Ram = Ram;
        this.wielkośćDysku = wielkośćDysku;
        }
      

    class Baza
    { Komputer[] bazaKomp;
      int rozmiar;
      char sep1 = ','; 
      string path;
    
      public Baza (Komputer[] bazaKomp)
      {this.bazaKomp = {new Komputer(WczytajZDysku(path)[1].Split(','))};
      }

      public string[] WczytajZDysku (string path)
      {StreamReader sr = new StreamReader (path);
    
       int a = 0;
       string[] tmp = new string[rozmiar];

       while (sr.ReadLine()!=null)
       {
         tmp[a] = sr.ReadLine();
         a++;
        }
       return tmp;
      } 

    }
   
    
    

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
