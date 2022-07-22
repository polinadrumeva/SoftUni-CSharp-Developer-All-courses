namespace Vehicles.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Car : Vehicle
    {
        private const double carIncreased = 0.9;

        public Car(double quantity, double comsumption) 
            : base(quantity, comsumption + carIncreased)
        {
        }
    }
}
