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

            Vehicle car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));
            Vehicle truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));

            IEngine engine = new Engine(car, truck);
            engine.Start();
        }
    }
}
