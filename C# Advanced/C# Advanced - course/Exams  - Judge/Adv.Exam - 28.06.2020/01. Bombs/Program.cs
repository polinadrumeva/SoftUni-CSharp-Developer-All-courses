using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceEffects = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();    
            int[] sequenceCasing = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Dictionary<string, int> bombs = new Dictionary<string, int>()
            { {"Datura Bombs", 0 },
              {"Cherry Bombs", 0 },
              { "Smoke Decoy Bombs", 0}
            };

            Queue<int> effects = new Queue<int>(sequenceEffects);
            Stack<int> casing = new Stack<int>(sequenceCasing);

            for (int i = 0; i < effects.Count; i++)
            {
                int sum = effects.Peek() + casing.Peek();
                if (sum == 40 || sum == 60 || sum == 120)
                {
                    if (sum == 40)
                    {
                        bombs["Datura Bombs"]++;
                    }
                    else if (sum == 60)
                    {
                        bombs["Cherry Bombs"]++;
                    }
                    else if (sum == 120)
                    {
                        bombs["Smoke Decoy Bombs"]++;
                    }

                    effects.Dequeue();
                    casing.Pop();
                }
                else
                {
                    int left = casing.Peek() - 5;
                    casing.Pop();
                    casing.Push(left);
                }

                if (casing.Count == 0 || bombs.Sum(x => x.Value) > 9)
                {
                    break;
                }

                i = -1;
            }


            if (bombs.Sum(x => x.Value) >= 9)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }

            if (casing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casing)}");
            }

            foreach (var bomb in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
