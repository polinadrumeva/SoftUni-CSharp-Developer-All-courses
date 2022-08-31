using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceLilies = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] sequenceRoses = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int wreath = 0;
            int goals = 5;
            int storedFlowers = 0;

            Queue<int> roses = new Queue<int>(sequenceRoses);
            Stack<int> lilies = new Stack<int>(sequenceLilies);

            for (int i = 0; i < roses.Count; i++)
            {
                int sum = roses.Peek() + lilies.Peek();
                if (sum == 15)
                { 
                    wreath++;
                    roses.Dequeue();
                    lilies.Pop();
                }
                else if (sum > 15)
                {
                    int left = lilies.Peek() - 2;
                    lilies.Pop();
                    lilies.Push(left);
                }
                else if (sum < 15)
                {
                    storedFlowers += sum;
                    roses.Dequeue();
                    lilies.Pop();
                }
                if (lilies.Count == 0)
                {
                    break;
                }

                i = -1;
            }

            if (storedFlowers > 15)
            {
                int wreathLeft = storedFlowers / 15;
                wreath += wreathLeft;
            }

            if (wreath >= goals)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreath} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {goals-wreath} wreaths more!");
            }

        }
    }
}
