namespace Vehicles.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelComsumption { get; }
        public double TankCapacity { get; }



        string Drive(double distance);

        void Refueled(double fuel);
    }
}
