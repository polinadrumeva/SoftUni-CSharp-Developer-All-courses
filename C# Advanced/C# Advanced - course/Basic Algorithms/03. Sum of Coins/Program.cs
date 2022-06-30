using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Sum_of_Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coins = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).OrderByDescending(x => x));
            int target = int.Parse(Console.ReadLine());
            Dictionary<int, int> usedCoins = new Dictionary<int, int>();
            int totalCoins = 0;

            while (target > 0 && coins.Count > 0)
            {
                int currentCoin = coins.Dequeue();
                int count = target / currentCoin;

                if (count == 0)
                {
                    continue;
                }

                usedCoins[currentCoin] = count;
                totalCoins += count;
                target %= currentCoin;

            }

            if (target > 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {totalCoins}");
                foreach (var item in usedCoins)
                {
                    Console.WriteLine($"{item.Value} coin(s) with value {item.Key}");
                }
            }


        }
    }
}
