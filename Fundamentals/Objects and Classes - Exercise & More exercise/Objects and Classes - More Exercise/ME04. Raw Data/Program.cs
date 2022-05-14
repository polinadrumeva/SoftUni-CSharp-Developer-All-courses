using System;
using System.Collections.Generic;
using System.Linq;

namespace ME04._Raw_Data
{
    class Car
    {
        public string Model { get; set; }
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType)
        {
            this.Model = model;
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;

        }

    }
   
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int numbersOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbersOfCars; i++)
            {
                string[] carInformation = Console.ReadLine().Split();
                string model = carInformation[0];
                int engineSpeed = int.Parse(carInformation[1]);
                int enginePower = int.Parse(carInformation[2]);
                int cargoWeight = int.Parse(carInformation[3]);
                string cargoType = carInformation[4];

              
                Car newCar = new Car( model, engineSpeed, enginePower, cargoWeight, cargoType);
                cars.Add(newCar);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                foreach (Car newCar in cars)
                {
                    if (newCar.CargoType == "fragile" && newCar.CargoWeight < 1000)
                    {
                        Console.WriteLine($"{newCar.Model}");
                    }
                }
            }
            else if (command == "flamable")
            {
                foreach (Car newCar in cars)
                {
                    if (newCar.CargoType == "flamable" && newCar.EnginePower > 250)
                    {
                        Console.WriteLine($"{newCar.Model}");
                    }
                }
            }
        }
    }
}
