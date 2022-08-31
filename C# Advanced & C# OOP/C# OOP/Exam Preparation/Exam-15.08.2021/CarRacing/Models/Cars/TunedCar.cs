namespace CarRacing.Models.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class TunedCar : Car
    {
        private const double fuelAvailableTunedCar = 65;
        private const double fuelConsumptionTunedCar = 7.5;
        public TunedCar(string make, string model, string vin, int horsePower) : base(make, model, vin, horsePower, fuelAvailableTunedCar, fuelConsumptionTunedCar)
        {
        }

        public override void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
            this.HorsePower -= (int)0.3 * this.HorsePower;
        }
    }
}
