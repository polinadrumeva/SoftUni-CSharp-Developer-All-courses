using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceHat = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] sequenceScarfs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> hats = new Stack<int>(sequenceHat);
            Queue<int> scarfs = new Queue<int>(sequenceScarfs);
            List<int> sets = new List<int>();

            for (int i = 0; i < hats.Count; i++)
            {
                if (scarfs.Count == 0)
                {
                    break;
                }
                
                if (hats.Peek() > scarfs.Peek())
                {
                    int set = hats.Peek() + scarfs.Peek();
                    sets.Add(set);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (hats.Peek() < scarfs.Peek())
                {
                    hats.Pop();
                }
                else if (hats.Peek() == scarfs.Peek())
                {
                    scarfs.Dequeue();
                    int toAdd = hats.Peek() + 1;
                    hats.Pop();
                    hats.Push(toAdd);
                }

                i = -1;
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(String.Join(" ", sets));
        }
    }
}
