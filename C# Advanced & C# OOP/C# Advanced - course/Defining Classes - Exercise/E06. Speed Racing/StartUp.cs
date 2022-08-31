using System;
using System.Collections.Generic;

namespace E06.SpeedRacing
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine().Split(" ");
                string model = cmdArg[0];
                double fuelAmount = double.Parse(cmdArg[1]);
                double fuelPerKm = double.Parse(cmdArg[2]);
                Car newcar = new Car(model, fuelAmount, fuelPerKm, 0);
                cars.Add(model, newcar);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmd = command.Split(" ");
                string carModel = cmd[1];
                double distance  = double.Parse(cmd[2]);
                foreach (var car in cars)
                {
                    if (carModel == car.Value.Model)
                    {
                        if (car.Value.Drive(car.Value, distance) == 0)
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                            break;
                        }
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:f2} {car.Value.TravelledDistance}");
            }
        }
    }
}
