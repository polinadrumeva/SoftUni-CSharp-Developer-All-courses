using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
       private const double DefaultFuelConsumption = 8;
        public override double FuelConsumption { get { return DefaultFuelConsumption; } }

        public RaceMotorcycle(int horsePower, int fuel) 
            : base(horsePower, fuel)
        {
        }

        public override void Drive(double kilometers)
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
