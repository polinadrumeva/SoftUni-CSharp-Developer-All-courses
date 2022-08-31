using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        private double year;
        private double pressure;

        public double Year { get; set; }
        public double Pressure { get; set; }

        public Tire(double year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

    }
}
