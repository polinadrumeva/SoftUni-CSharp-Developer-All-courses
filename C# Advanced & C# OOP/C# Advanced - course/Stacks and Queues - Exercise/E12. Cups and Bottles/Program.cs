using System;
using System.Collections.Generic;
using System.Linq;

namespace E12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] filledBottles = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>(filledBottles);
            Queue<int> cups = new Queue<int>(cupsCapacity);
            int wastedWater = 0;

            while (cups.Count != 0)
            {
                if (bottles.Peek() >= cups.Peek())
                {
                    wastedWater += bottles.Peek() - cups.Peek();
                    bottles.Pop();
                    cups.Dequeue();
                }
                else if (bottles.Peek() < cups.Peek())
                {
                    int difference = cups.Peek() - bottles.Peek();
                    int[] changed = cups.ToArray();
                    cups.Clear();
                    changed[0] = difference;
                    cups = new Queue<int>(changed);
                    bottles.Pop();
                    
                }

                if (bottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    return;
                }
            }

            Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
