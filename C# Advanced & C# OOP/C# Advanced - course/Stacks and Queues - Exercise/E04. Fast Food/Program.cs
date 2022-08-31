using System;
using System.Collections.Generic;
using System.Linq;

namespace E04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] quantityOfOrders = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> queueForRestaurant = new Queue<int>(quantityOfOrders);
            Console.WriteLine(queueForRestaurant.Max());

            while (queueForRestaurant.Count != 0)
            {
                int current = queueForRestaurant.Peek();
                if (quantityOfFood < current)
                {
                    break;
                }
                else if (quantityOfFood >= current)
                {
                    quantityOfFood -= current;
                    queueForRestaurant.Dequeue();
                }
            }
             
            if (queueForRestaurant.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queueForRestaurant)}");
            }

        }
    }
}
