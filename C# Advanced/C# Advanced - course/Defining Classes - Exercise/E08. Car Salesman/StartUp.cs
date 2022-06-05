using System;
using System.Collections.Generic;
using System.Linq;

namespace E08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] dataEngine = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = dataEngine[0];
                int power = int.Parse(dataEngine[1]);

                if (dataEngine.Length == 2)
                {
                    Engine engine = new Engine(model, power, 0, null);
                    engines.Add(engine);
                }
                else if (dataEngine.Length == 4)
                {
                    int displacement = int.Parse(dataEngine[2]);
                    string efficiency = dataEngine[3];
                    Engine engine = new Engine(model, power, displacement, efficiency);
                    engines.Add(engine);

                }
                else if (int.TryParse(dataEngine[2], out int b))
                {
                    int displacement = int.Parse(dataEngine[2]);
                    Engine engine = new Engine(model, power, displacement, null);
                    engines.Add(engine);
                }
                else 
                { 
                    string efficiency = dataEngine[2];
                    Engine engine = new Engine(model, power, 0, efficiency);
                    engines.Add(engine);
                }
               
            }

            int m = int.Parse(Console.ReadLine());
            for (int j = 0; j < m; j++)
            {
                string[] dataCars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = dataCars[0];
                string engineName = dataCars[1];
                
                if (dataCars.Length == 2)
                {
                    Car newcar = new Car(model, engines.Where(x => x.Model == engineName).First(), 0, null);
                    cars.Add(newcar);
                }
                else if (dataCars.Length == 4)
                {
                    int weight = int.Parse(dataCars[2]);
                    string color = dataCars[3];
                    Car newcar = new Car(model, engines.Where(x => x.Model == engineName).First(), weight, color);
                    cars.Add(newcar);

                }
                else if (int.TryParse(dataCars[2], out int b))
                {
                    int weight = int.Parse(dataCars[2]);
                    Car newcar = new Car(model, engines.Where(x => x.Model == engineName).First(), weight, null);
                    cars.Add(newcar);
                }
                else
                {
                    string color = dataCars[2];
                    Car newcar = new Car(model, engines.Where(x => x.Model == engineName).First(), 0, color);
                    cars.Add(newcar);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($" {car.Engine.Model}:");
                Console.WriteLine($"   Power: {car.Engine.Power}");
                if (car.Engine.Displacement != 0)
                {
                    Console.WriteLine($"   Displacement: {car.Engine.Displacement}");
                }
                else
                {
                    Console.WriteLine($"   Displacement: n/a");
                }
                if (car.Engine.Efficiency != null)
                {
                    Console.WriteLine($"   Efficiency: {car.Engine.Efficiency}");
                }
                else
                {
                    Console.WriteLine($"   Efficiency: n/a");
                }
                if (car.Weight != 0)
                {
                    Console.WriteLine($" Weight: {car.Weight}");
                }
                else
                {
                    Console.WriteLine($" Weight: n/a");
                }
                if (car.Color != null)
                {
                    Console.WriteLine($" Color: {car.Color}");
                }
                else
                {
                    Console.WriteLine($" Color: n/a");
                }
            }
        }
    }
}
