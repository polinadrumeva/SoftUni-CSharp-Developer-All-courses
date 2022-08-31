namespace Facade
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info.WithType("BMW").WithColor("White").WithDoors(5)
                .Built.InCity("Berlin").AtAddress("Main 34")
                .Build();

            Console.WriteLine(car);
        }
    }
}
