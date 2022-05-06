using System;
using System.Collections.Generic;

namespace E06._Vehicle_Catalogue
{
    class Cars
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        public Cars(string type, string model, string color, double horsePower)
        { 
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
    }
    class Trucks
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        public Trucks(string type, string model, string color, double horsePower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cars> cars = new List<Cars>();
            List<Trucks> trucks = new List<Trucks>();

            string vehicleOrEnd = Console.ReadLine();
            while (vehicleOrEnd != "End")
            {
                string[] vehicleInformation = vehicleOrEnd.Split();
                string type = vehicleInformation[0];
                string model = vehicleInformation[1];
                string color = vehicleInformation[2];
                double horsePower = double.Parse(vehicleInformation[3]);

                if (type == "car")
                {
                    Cars newCar = new Cars(type, model, color, horsePower);
                    cars.Add(newCar);

                }
                else if (type == "truck")
                {
                    Trucks newTrucks = new Trucks(type, model, color, horsePower);
                    trucks.Add(newTrucks);  
                }

                vehicleOrEnd = Console.ReadLine();
            }

            string vehicle = Console.ReadLine();
            while (vehicle != "Close the Catalogue")
            {
                foreach (Cars newCar in cars)
                {
                    if (vehicle == newCar.Model)
                    {
                        Console.WriteLine("Type: Car");
                        Console.WriteLine($"Model: {newCar.Model}");
                        Console.WriteLine($"Color: {newCar.Color}");
                        Console.WriteLine($"Horsepower: {newCar.HorsePower}");
                    }
                }
                foreach (Trucks newTruck in trucks)
                {
                    if (vehicle == newTruck.Model)
                    {
                        Console.WriteLine("Type: Truck");
                        Console.WriteLine($"Model: {newTruck.Model}");
                        Console.WriteLine($"Color: {newTruck.Color}");
                        Console.WriteLine($"Horsepower: {newTruck.HorsePower}");
                    }
                }

                vehicle = Console.ReadLine();
            }
            double totalHorsePowerCars = 0;
            double totalHorsePowerTrucks = 0;
            foreach (Cars newCar in cars)
            {
                totalHorsePowerCars += newCar.HorsePower;
            }
            foreach (Trucks newTruck in trucks)
            {
                totalHorsePowerTrucks += newTruck.HorsePower;
            }
            double averagePowerCars; 
            if (cars.Count == 0)
            {
               averagePowerCars = 0;
            }
            else
            {
                averagePowerCars = totalHorsePowerCars / cars.Count;
            }

            double averagePowerTrucks;
            if (trucks.Count == 0)
            {
                averagePowerTrucks = 0;
 
            }
            else
            {
                averagePowerTrucks = totalHorsePowerTrucks / trucks.Count;
            }
            
            Console.WriteLine($"Cars have average horsepower of: {averagePowerCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averagePowerTrucks:f2}.");
            
        }
    }
}
