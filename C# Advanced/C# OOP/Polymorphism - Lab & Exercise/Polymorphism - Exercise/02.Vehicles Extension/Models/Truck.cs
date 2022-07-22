namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Truck : Vehicle
    {
        private const double truckIncreased = 1.6;
        private const double truckCoefficient = 0.95;
        public Truck(double quantity, double comsumption, double capacity)
            : base(quantity, comsumption + truckIncreased, capacity)
        {
            if (quantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
        }

        public override void Refueled(double fuel)
        {
            double truckFuel = fuel * truckCoefficient;
           
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + truckFuel > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += truckFuel;
            }

            
        }
    }
}
