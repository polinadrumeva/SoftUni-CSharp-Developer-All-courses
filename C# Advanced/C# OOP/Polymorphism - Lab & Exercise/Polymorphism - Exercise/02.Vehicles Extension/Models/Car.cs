namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Car : Vehicle
    {
        private const double carIncreased = 0.9;

        public Car(double quantity, double comsumption, double capacity)
            : base(quantity, comsumption + carIncreased, capacity)
        {
            if (quantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
        }
    }
}
