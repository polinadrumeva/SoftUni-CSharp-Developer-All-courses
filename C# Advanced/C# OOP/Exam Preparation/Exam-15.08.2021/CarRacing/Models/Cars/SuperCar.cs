namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class SuperCar : Car
    {
        public SuperCar(string make, string model, string vin, int horsePower, double fuelAvailabe, double fuelConsumption) : base(make, model, vin, horsePower, fuelAvailabe, fuelConsumption)
        {
        }
    }
}
