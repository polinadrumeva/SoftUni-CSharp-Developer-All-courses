using System;
using System.Collections.Generic;
using System.Text;

namespace E06.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKm;
        private double travelledDsitance;

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelPerKm, double travelledDistance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelPerKm;
            this.TravelledDistance = travelledDistance;
        }

        public double Drive(Car newcar, double distance)
        {
            if (distance * this.FuelConsumptionPerKilometer <= this.FuelAmount)
            {
                this.TravelledDistance += distance;
                return this.FuelAmount -= distance * this.FuelConsumptionPerKilometer;
            }
            else
            {
                return 0;
            }
        }
    }
}
