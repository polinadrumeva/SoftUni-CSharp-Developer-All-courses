using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        private double horsePower;
        private double cubicCapacity;

        public double HorsePower { get; set; }
        public double CubicCapacity { get; set; }


        public Engine(double horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }
}
