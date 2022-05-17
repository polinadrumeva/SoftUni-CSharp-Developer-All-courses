using System;
using System.Collections.Generic;
using System.Linq;

namespace E07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> pumps = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] petrolPump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Push(petrolPump[0]);
                pumps.Push(petrolPump[1]);
            }

            Console.WriteLine(pumps.Min());
        }
    }
}
