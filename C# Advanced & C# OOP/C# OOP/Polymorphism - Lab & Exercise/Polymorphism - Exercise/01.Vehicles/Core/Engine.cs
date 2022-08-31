namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models.Interfaces;
    public class Engine : IEngine
    {
        private readonly IVehicle car;
        private readonly IVehicle truck;
        public Engine(IVehicle car, IVehicle truck)
        {
            this.car = car;
            this.truck = truck;
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
                }


            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
        }
    }
}
