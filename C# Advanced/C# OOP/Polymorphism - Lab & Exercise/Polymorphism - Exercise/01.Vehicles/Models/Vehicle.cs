namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;


    public abstract class Vehicle : IVehicle
    {
        public double FuelQuantity { get; set; }

        public double FuelComsumption { get; set; }

        public Vehicle(double quantity, double comsumption)
        {
            this.FuelComsumption = quantity;
            this.FuelComsumption = comsumption;
        }

        public string Drive(double distance)
        {
            throw new NotImplementedException();
        }

        public void Refueled(double fuel)
        {
            throw new NotImplementedException();
        }
    }
}
