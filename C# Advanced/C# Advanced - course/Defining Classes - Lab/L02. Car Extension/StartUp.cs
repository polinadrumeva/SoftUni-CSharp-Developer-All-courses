using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car newcar = new Car();

            newcar.Make = "VW";
            newcar.Model = "MK3";
            newcar.Year = 1992;
            newcar.FuelQuantity = 200;
            newcar.FuelConsumption = 200;
            newcar.Drive(2000);
            Console.WriteLine(newcar.WhoAmI());
        }
    }
}
