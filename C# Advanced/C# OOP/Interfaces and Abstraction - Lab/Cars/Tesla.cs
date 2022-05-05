using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02.Cars
{
    public class Tesla : ICar, IElectricCar
    {
      
        public string Model { get; set; }

        public string Color { get; set; }

        public int Battery { get; set; }

        public Tesla (string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }


        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }

        public void ToString()
        {
            Console.WriteLine($"{this.Color} Tesla {this.Model} with {this.Battery} Batteries");
            Console.WriteLine($"{this.Start()}");
            Console.WriteLine($"{this.Stop()}");
        }

    }
}
