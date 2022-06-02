using System;

namespace CarManufacturer
{
  
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car newcar = new Car();
            newcar.Make = "Mercedes";
            newcar.Model = "E30";
            newcar.Year = 2021;

            Console.WriteLine($"Make: {newcar.Make}, Model: {newcar.Model}, Year: {newcar.Year}");
        }
    }
}
