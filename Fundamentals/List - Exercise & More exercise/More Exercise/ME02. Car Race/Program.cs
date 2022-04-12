using System;
using System.Linq;

namespace ME02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] race = Console.ReadLine().Split().Select(int.Parse).ToArray();
            double firstTime = 0;
            double secondTime = 0;

            for (int i = 0; i < race.Length /2; i++)
            {
                if (race[i] == 0)
                {
                    firstTime *= 0.80;
                }
                else
                {
                    firstTime += race[i];
                }
            }

            for (int k = race.Length -1; k > race.Length / 2; k--)
            {
                if (race[k] == 0)
                {
                    secondTime *= 0.80;
                }
                else
                {
                    secondTime += race[k];
                }
            }

            if (firstTime < secondTime)
            {
                Console.WriteLine($"The winner is left with total time: {Math.Round(firstTime,1)}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {Math.Round(secondTime, 1)}");
            }
        }
    }
}
