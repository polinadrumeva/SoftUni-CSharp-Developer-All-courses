using System;
using System.Collections.Generic;
using System.Linq;

namespace E06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> second = Console.ReadLine().Split().Select(int.Parse).ToList();
            int counter = 0;
            int minLenght = Math.Min(first.Count, second.Count);

            for (counter = 0; counter < minLenght; counter++)
            {
                if (counter > first.Count || counter > second.Count || first.Count == 0 || second.Count == 0)
                {
                    break;
                }
                else if (first[counter] > second[counter])
                {
                    first.Add(second[counter]);
                    first.Add(first[counter]);
                    first.RemoveAt(counter);
                    second.RemoveAt(counter);

                }
                else if (first[counter] < second[counter])
                {
                    second.Add(first[counter]);
                    second.Add(second[counter]);
                    first.RemoveAt(counter);
                    second.RemoveAt(counter);

                }
                else if (first[counter] == second[counter])
                {
                    first.RemoveAt(counter);
                    second.RemoveAt(counter);
                }
                counter = -1;
            }

            if (first.Count > second.Count)
            {
                int sum = first.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else if (first.Count < second.Count)
            {
                int sum = second.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
