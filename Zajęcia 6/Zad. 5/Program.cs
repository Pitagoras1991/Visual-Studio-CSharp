using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad._5
{
    /*a. Zdefiniuj dwa interfejsy IMovable (do startowania i zatrzymywania) oraz ISteerable
     * (do skręcania), a następnie zaimplementuj oba te interfejsy w jednej klasie Car. Dodaj
     * też metodę ToString.
b. Dodatkowo wyprowadź klasę Car także z klasy MotorVehicle. Dodaj interfejs IAccelerable
     * do przyspieszania i zwalniania. */

    interface IMovable
    { void Start();
      void Stop();
    }

    interface ISteerable
    { void Turn(bool kierunek);}

    interface IAccelerable
    {void Accelerate();}

    class MotorVehicle: IMovable,ISteerable, IAccelerable
    {
        private string description;
        private int maxSpeed;
        private int speed;

        public MotorVehicle(string description, int maxSpeed, int speed)
        {
            this.description = description;
            this.maxSpeed = maxSpeed;
            this.speed = speed;
        }


        public string Description
        {
            get
            {
                return description;
            }
        }

        public int MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
        }

           public int Speed
        {
            get
            {
                return speed;
            }
        }

        public virtual void Start()
        {   speed = 0;
            Console.WriteLine("MotorVehicle ruszył"); }

        public virtual void Stop()
        { speed = 0;}

        public virtual void Turn(bool kierunek)
        { if(kierunek == true) Console.WriteLine("Skręcono w lewo");
          else Console.WriteLine("Skręcono w prawo");}

        public virtual void Accelerate()
        { while(speed < maxSpeed)
            { speed++;}}
    }



    class Car : MotorVehicle
    { 
        string marka;
         public Car(string description, int maxSpeed, int speed, string marka):base(description,maxSpeed,speed)
         { this.marka = marka; }
        
      }

   

    class Program
    {
        static void Main(string[] args)
        {
            Car Toyota = new Car("Niebieski metallic", 260, 0, "Toyota Avensis");
            Toyota.Start();
            Toyota.Accelerate();
            Toyota.Turn(true);
            Console.WriteLine(Toyota.Speed);
            Console.ReadKey();

        }
    }
}
