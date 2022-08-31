using System;
using System.Collections.Generic;
using System.Text;

namespace E08.CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }

        public int Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine Engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = Engine;
            this.Weight = weight;
            this.Color = color;
        }
    }
}
