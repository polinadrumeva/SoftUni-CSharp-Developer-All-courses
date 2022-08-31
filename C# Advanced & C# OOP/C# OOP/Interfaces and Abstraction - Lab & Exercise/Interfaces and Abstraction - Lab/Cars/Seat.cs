using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
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

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.Color} Seat {this.Model}")
                .AppendLine($"{this.Start()}")
                .AppendLine($"{this.Stop()}");

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
