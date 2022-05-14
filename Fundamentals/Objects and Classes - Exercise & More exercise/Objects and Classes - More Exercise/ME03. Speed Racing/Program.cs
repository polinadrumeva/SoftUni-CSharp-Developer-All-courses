using System;
using System.Collections.Generic;
using System.Linq;

namespace ME03._Speed_Racing
{
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }

        public double FuelConsumptionForKm { get; set; }
        public List<double> TravelledDistance { get; set; }

        public Car(string model,double fuelAmount, double consumptionForKm,double amountDistance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionForKm = consumptionForKm;
            this.TravelledDistance = new List<double>();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int numbersOfCars = int.Parse(Console.ReadLine());
            double amountKm = 0;

            for (int i = 1; i <= numbersOfCars; i++)
            {
                string[] carsInformation = Console.ReadLine().Split().ToArray();
                string model = carsInformation[0];
                double fuelAmount = double.Parse(carsInformation[1]);
                double consumptionForKm = double.Parse(carsInformation[2]);

                Car newCar = new Car(model, fuelAmount, consumptionForKm, amountKm);
                cars.Add(newCar);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] driveCommands = command.Split().ToArray(); 
                string carModel = driveCommands[1];
                amountKm = double.Parse(driveCommands[2]);

                foreach (Car newCar in cars)
                {
                    if (newCar.Model == carModel)
                    {
                        if (newCar.FuelConsumptionForKm * amountKm <= newCar.FuelAmount)
                        {
                            newCar.TravelledDistance.Add(amountKm);
                            newCar.FuelAmount -= newCar.FuelConsumptionForKm * amountKm;
                        }
                        else
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                        }
                    }
                }
               
            }

            foreach (Car newCar in cars)
            {
                Console.WriteLine($"{newCar.Model} {newCar.FuelAmount:f2} {newCar.TravelledDistance.Sum()} ");
            }

        }
       
    }
}
