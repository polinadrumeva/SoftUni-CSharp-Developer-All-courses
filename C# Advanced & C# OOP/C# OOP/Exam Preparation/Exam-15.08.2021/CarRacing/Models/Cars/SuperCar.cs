namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class SuperCar : Car
    {
        private const double fuelAvailableSuperCar = 80;
        private const double fuelConsumptionSuperCar = 10;
        public SuperCar(string make, string model, string vin, int horsePower) : base(make, model, vin, horsePower, fuelAvailableSuperCar, fuelConsumptionSuperCar)
        {
        }

        public override void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
        }
    }
}
