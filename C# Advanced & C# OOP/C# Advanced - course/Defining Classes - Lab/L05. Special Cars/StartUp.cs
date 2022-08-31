using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string tiresLine;
            int countTire = 0;
            List<Tire[]> allTires = new List<Tire[]>();
            while ((tiresLine = Console.ReadLine()) != "No more tires")
            {
                var tires = tiresLine.Split(' ').Select(double.Parse).ToArray();
                var tire = new Tire[4];
                for (int i = 0; i < tires.Length - 1; i+=2)
                {
                    tire[countTire] = new Tire(tires[i], tires[i+1]);
                }
                allTires.Add(tire);
                countTire = 0;
            }

            string engineLine;
            List<Engine> allEngines = new List<Engine>();
            while ((engineLine = Console.ReadLine()) != "Engines done")
            {
                var engines = engineLine.Split(' ').Select(double.Parse).ToArray();
                var engine = new Engine(engines[0], engines[1]);
                allEngines.Add(engine);
            }

            string modelsLine;
            List<Car> allCars = new List<Car>();
            while ((modelsLine = Console.ReadLine()) != "Show special")
            {
                var models = modelsLine.Split(' ').ToArray();
                var newCar = new Car(models[0], models[1], int.Parse(models[2]), double.Parse(models[3]), double.Parse(models[4]), allEngines[int.Parse(models[5])], allTires[int.Parse(models[6])]);
                allCars.Add(newCar);
            }

            List<Car> selectedCar = new List<Car>();
            foreach (var item in allCars)
            {
                if (item.Year >= 2017 && item.Engine.HorsePower >= 330)
                {
                   selectedCar.Add(item);
                }
            }

            foreach (var each in selectedCar)
            {
                Console.WriteLine($"Make: {each.Make}");
                Console.WriteLine($"Model: {each.Model}");
                Console.WriteLine($"Year: {each.Year}");
                Console.WriteLine($"HorsePowers: {each.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {each.FuelQuantity}");


            }
        }
    }
}
