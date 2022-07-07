using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Tesla {this.Model} with {this.Battery} Batteries")
                .AppendLine($"{this.Start()}")
                .AppendLine($"{this.Stop()}");

            return sb.ToString().TrimEnd();
        }

    }
}
