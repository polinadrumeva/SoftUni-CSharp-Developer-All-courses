using System;
using System.Collections.Generic;
using System.Linq;

namespace E11.Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());
            int countGunBarrel = 0;
            int countBullets = 0;

            Stack<int> stackOfBullets = new Stack<int>(bullets);
            Queue<int> queueOfLocks = new Queue<int>(locks);

            while (queueOfLocks.Count != 0)
            {
                if (stackOfBullets.Peek() <= queueOfLocks.Peek())
                {
                    Console.WriteLine("Bang!");
                    queueOfLocks.Dequeue();
                    stackOfBullets.Pop();
                    countGunBarrel++;
                    countBullets++;
                }
                else if (stackOfBullets.Peek() > queueOfLocks.Peek())
                {
                    Console.WriteLine("Ping!");
                    stackOfBullets.Pop();
                    countGunBarrel++;
                    countBullets++;
                }
                if (countGunBarrel == sizeOfGunBarel && stackOfBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    countGunBarrel = 0;
                }
                if (stackOfBullets.Count == 0 && queueOfLocks.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {queueOfLocks.Count}");
                    return;
                }

            }
            int earnedMoney = valueOfIntelligence - (countBullets * priceOfBullet);
            Console.WriteLine($"{stackOfBullets.Count} bullets left. Earned ${earnedMoney}");
        }
    }
}
