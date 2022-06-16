using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex01._Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] first = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] second = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(first);
            Stack<int> secondBox = new Stack<int>(second);
            List<int> collection = new List<int>();
            int sum = 0;

            for (int i = 0; i < firstBox.Count; i++)
            { 
                sum = firstBox.Peek() + secondBox.Peek();
                if (sum % 2 == 0)
                {
                    collection.Add(sum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    int lastPosition = secondBox.Peek();
                    secondBox.Pop();
                    firstBox.Enqueue(lastPosition);
                }

                if (secondBox.Count == 0)
                {
                    break;
                }

                i = -1;
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int collectionSum = collection.Sum();
            if (collectionSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collectionSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collectionSum}");
            }
        }
    }
}
