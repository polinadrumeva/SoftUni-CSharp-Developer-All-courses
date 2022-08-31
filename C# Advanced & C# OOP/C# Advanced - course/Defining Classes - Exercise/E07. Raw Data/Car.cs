using System;
using System.Collections.Generic;
using System.Text;


namespace E07.RawData
{
    public class Car 
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public List<Tires> Tires { get; set; }

        public Car(string model, Engine engine, Cargo cargo, List<Tires> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

    }
}
