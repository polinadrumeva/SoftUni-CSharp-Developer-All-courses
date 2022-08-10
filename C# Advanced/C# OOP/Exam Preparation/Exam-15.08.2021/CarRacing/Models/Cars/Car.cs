namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumption;
        public string Make => throw new NotImplementedException();

        public string Model => throw new NotImplementedException();

        public string VIN => throw new NotImplementedException();

        public int HorsePower => throw new NotImplementedException();

        public double FuelAvailable => throw new NotImplementedException();

        public double FuelConsumptionPerRace => throw new NotImplementedException();

        public Car(string make, string model, string vin, int horsePower, double fuelAvailabe, double fuelConsumption)
        {
            
        }
        public void Drive()
        {
            throw new NotImplementedException();
        }
    }
}
