using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._7
{
    class ZamianaJednostek
    {
        private int liczba;
        double długość;
        double masa;
        double temp;
        double moc;
        double objętość;

        public int Liczba
        {
            set
            {
                if (value >= 0) liczba = value;
                else liczba = 0;
            }

            get { return liczba; }
        }

        public int LiczbaMendli
        {
            set
            {
                if (value >= 0) liczba = value;
                else liczba = 0;
            }

            get { return (int)Math.Floor((decimal)liczba / 15); }
        }

        public int LiczbaKop
        {
            set
            {
                if (value >= 0) liczba = value;
                else liczba = 0;
            }

            get { return (int)Math.Floor((decimal)liczba / 60); }
        }

        public int LiczbaTuzinów
        {
            set
            {
                if (value >= 0) liczba = value;
                else liczba = 0;
            }

            get { return (int)Math.Floor((decimal)liczba/ 12); }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ZamianaJednostek z = new ZamianaJednostek();
            z.Liczba = 84;
            Console.WriteLine(z.LiczbaKop);
            Console.WriteLine(z.LiczbaMendli);
            Console.WriteLine(z.LiczbaTuzinów);
            Console.ReadKey();
        }
    }
}
