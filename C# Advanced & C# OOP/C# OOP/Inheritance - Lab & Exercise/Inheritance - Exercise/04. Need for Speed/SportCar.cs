using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DefaultFuelConsumption = 10;
        public override double FuelConsumption { get { return DefaultFuelConsumption; } }

        public SportCar(int horsePower, int fuel) 
            : base(horsePower, fuel)
        {
        }

        public override void Drive(double kilometers)
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
