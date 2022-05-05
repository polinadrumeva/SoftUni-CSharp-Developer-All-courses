using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L02.Cars
{
    public class Seat : ICar
    {
        public string Name { get; set; }
        public string Model { get; set; }

        public string  Color { get; set; }

        public Seat( string model, string color)
        {
            this.Model = model; 
            this.Color = color;
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
            Console.WriteLine($"{this.Color} Seat {this.Model}");
            Console.WriteLine($"{this.Start()}");
            Console.WriteLine($"{this.Stop()}");
       
           
        }
    }
}
