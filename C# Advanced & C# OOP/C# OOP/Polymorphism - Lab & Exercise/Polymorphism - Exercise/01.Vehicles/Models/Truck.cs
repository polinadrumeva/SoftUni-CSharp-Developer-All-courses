namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Truck : Vehicle
    {
        private const double truckIncreased = 1.6;
        private const double truckCoefficient = 0.95;
        public Truck(double quantity, double comsumption)
            : base(quantity, comsumption + truckIncreased)
        {
        }

        public override void Refueled(double fuel)
        {
            base.Refueled(fuel * truckCoefficient);
        }
    }
}
