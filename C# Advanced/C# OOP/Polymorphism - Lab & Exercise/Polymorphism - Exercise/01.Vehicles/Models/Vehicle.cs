namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;


    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelComsumption;
        public double FuelQuantity { get; set; }

        public double FuelComsumption { get; protected set; }

        public Vehicle(double quantity, double comsumption)
        {
            this.FuelQuantity = quantity;
            this.FuelComsumption = comsumption;
        }

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

        public virtual void Refueled(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
