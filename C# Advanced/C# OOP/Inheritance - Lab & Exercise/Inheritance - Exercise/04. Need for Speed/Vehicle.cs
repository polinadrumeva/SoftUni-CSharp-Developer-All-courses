using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption { get { return DefaultFuelConsumption; } }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(int horsePower, int fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
