using System;

namespace CarManufacturer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new Tire[4]
                {
                new Tire(1, 2.5),
                new Tire(1, 2.5),
                new Tire(2, 3.5),
                new Tire(2, 3.5),
                };
            var engine = new Engine(10, 300);
            var car = new Car("lamborgine", "3E", 2024, 250, 9, engine, tires);
            Console.WriteLine($"{car.Make}, {car.Model}, {car.Year}");
        }
    }
}
