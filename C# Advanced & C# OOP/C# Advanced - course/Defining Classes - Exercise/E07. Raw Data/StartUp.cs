using System;
using System.Collections.Generic;
using System.Linq;

namespace E07.RawData
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            int index = 5;

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ");
                string model = data[0];
                double speed = double.Parse(data[1]);
                double power = double.Parse(data[2]);
                int weight = int.Parse(data[3]);
                string type = data[4];
                double tire1 = double.Parse(data[5]);
                int age1 = int.Parse(data[6]);
                double tire2 = double.Parse(data[7]);
                int age2 = int.Parse(data[8]);
                double tire3 = double.Parse(data[9]);
                int age3 = int.Parse(data[10]);
                double tire4 = double.Parse(data[11]);
                int age4 = int.Parse(data[12]);

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(type, weight);
                List<Tires> tires = new List<Tires>();
                for (int j = 0; j < 4; j++)
                {
                    Tires newtire = new Tires(double.Parse(data[index]), int.Parse(data[index + 1]));
                    tires.Add(newtire);
                    index += 2;
                }
                index = 5;
                Car newcar = new Car(model, engine, cargo, tires);
                cars.Add(newcar);
            }
            Predicate<double> match = x => x < 1;
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                foreach (var car in cars)
                {
                    foreach (var tire in car.Tires)
                    {
                        if (car.Cargo.Type == "fragile" && tire.Pressure < 1)
                        {
                            Console.WriteLine($"{car.Model}");
                            break;
                        }
                    }

                }
            }
            else if (command == "flammable")
            {
                foreach (var car in cars)
                {

                    if (car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                    {
                        Console.WriteLine($"{car.Model}");
                        continue;
                    }

                }

            }

        }
    }
}
