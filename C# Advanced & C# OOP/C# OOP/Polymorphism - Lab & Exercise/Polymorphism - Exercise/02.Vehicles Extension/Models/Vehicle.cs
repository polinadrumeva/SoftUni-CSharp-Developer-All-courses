namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using Vehicles.Core;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelComsumption;
        private double tankCapacity;
        public Vehicle(double quantity, double comsumption, double capacity)
        {
            this.FuelQuantity = quantity;
            this.FuelComsumption = comsumption;
            this.TankCapacity = capacity;
        }
        public double FuelQuantity { get; set; }

        public double FuelComsumption { get; protected set; }
        public double TankCapacity { get; protected set; }

        

        public string Drive(double distance)
        {
            double neededFuel = distance * this.FuelComsumption;
            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        internal void Start()
        {
            throw new NotImplementedException();
        }

        public virtual void Refueled(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += fuel;
            }

        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

        
    }
}
