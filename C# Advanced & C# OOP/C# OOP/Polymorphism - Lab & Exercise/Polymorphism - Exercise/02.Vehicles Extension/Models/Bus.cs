namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bus : Vehicle
    {
        private const double fullBusIncreased = 1.4;
        public Bus(double quantity, double comsumption, double capacity) 
            : base(quantity, comsumption + fullBusIncreased, capacity)
        {
            if (quantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
        }

        public string DriveEmpty(double distance)
        {
            double neededFuel = distance * (this.FuelComsumption - fullBusIncreased);
            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }
    }
}
