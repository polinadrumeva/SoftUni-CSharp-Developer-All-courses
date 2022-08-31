namespace Vehicles
{
    using System;
    using Models.Interfaces;
    using Models;
    using Core;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split(" ");
            string[] truckData = Console.ReadLine().Split(" ");
            string[] busData = Console.ReadLine().Split(" ");

            Car car = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));
            Truck truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));
            Bus bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));

            var engine = new Engine(car, truck, bus);
            engine.Start();
        }
    }
}
