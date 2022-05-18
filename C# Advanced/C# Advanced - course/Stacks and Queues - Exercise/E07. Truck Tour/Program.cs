using System;
using System.Collections.Generic;
using System.Linq;

namespace E07._Truck_Tour
{
    public class Pump
    {
        public int Number { get; set; }
        public int Amount { get; set; }
        public int Distance { get; set; }

        public Pump(int number, int amount, int distance)
        {
            this.Number = number;
            this.Amount = amount;
            this.Distance = distance;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<Pump> pumps = new Queue<Pump>();

            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();
                int amount = int.Parse(data.Split()[0]);
                int distance = int.Parse(data.Split()[1]);
                Pump pump = new Pump(i, amount, distance);
                pumps.Enqueue(pump);
            }

            int totalDistance = pumps.Sum(pump => pump.Distance);
            int truckDistance = 0;
            int truckFuel = 0;

            while (truckDistance < totalDistance)
            {
                Pump currentPump = pumps.Peek();
                truckFuel += currentPump.Amount;
                truckDistance+= currentPump.Distance;
                pumps.Dequeue();
                
            }
           
        }
    }
}
