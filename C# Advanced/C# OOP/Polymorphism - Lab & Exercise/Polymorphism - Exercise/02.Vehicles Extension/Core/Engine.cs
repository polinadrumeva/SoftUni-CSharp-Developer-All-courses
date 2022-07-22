namespace Vehicles.Core
{
    using System;
    using Models.Interfaces;
    using Models;

    public class Engine : IEngine
    {
        private readonly Car car;
        private readonly Truck truck;
        private readonly Bus bus; 
        public Engine(Car car, Truck truck, Bus bus)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }

        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine().Split(" ");
                string cmdType = cmdArg[0];
                string vehicleType = cmdArg[1];
                double cmdParams = double.Parse(cmdArg[2]);

                if (cmdType == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(this.car.Drive(cmdParams));

                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(this.truck.Drive(cmdParams));
                    }
                    else if (vehicleType == "Bus")
                    {
                        Console.WriteLine(this.bus.Drive(cmdParams));
                    }
                }
                else if (cmdType == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        this.car.Refueled(cmdParams);
                    }
                    else if (vehicleType == "Truck")
                    {
                        this.truck.Refueled(cmdParams);
                    }
                    else if (vehicleType == "Bus")
                    {
                        this.bus.Refueled(cmdParams);
                    }
                }
                else if (cmdType == "DriveEmpty")
                {
                    if (vehicleType == "Bus")
                    {
                        Console.WriteLine(this.bus.DriveEmpty(cmdParams));
                    }
                }


            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }
    }
}
