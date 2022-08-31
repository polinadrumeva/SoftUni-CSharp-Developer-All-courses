using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3;
        public override double FuelConsumption { get { return DefaultFuelConsumption; } }

        public Car(int horsePower, int fuel) 
            : base(horsePower, fuel)
        {

        }

        public override void Drive(double kilometers) 
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
