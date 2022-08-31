using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ex01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ing = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] fresh = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> ingredients = new Queue<int>(ing);
            Stack<int> freshness = new Stack<int>(fresh);
            int sum = 0;

            Dictionary<string, int> dishes = new Dictionary<string, int>();

            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                }
                sum = ingredients.Peek() * freshness.Peek();
                if (sum == 150)
                {
                    if (!dishes.ContainsKey("Dipping sauce"))
                    {
                        dishes.Add("Dipping sauce", 1);
                    }
                    else
                    {
                        dishes["Dipping sauce"]++;
                    }
                    ingredients.Dequeue();
                    freshness.Pop();

                }
                else if (sum == 250)
                {
                    if (!dishes.ContainsKey("Green salad"))
                    {
                        dishes.Add("Green salad", 1);
                    }
                    else
                    {
                        dishes["Green salad"]++;
                    }
                    
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (sum == 300)
                {
                    if (!dishes.ContainsKey("Chocolate cake"))
                    {
                        dishes.Add("Chocolate cake", 1);
                    }
                    else
                    {
                        dishes["Chocolate cake"]++;
                    }
                    
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (sum == 400)
                {
                    if (!dishes.ContainsKey("Lobster"))
                    {
                        dishes.Add("Lobster", 1);
                    }
                    else
                    {
                        dishes["Lobster"]++;
                    }
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    int left = ingredients.Peek() + 5;
                    ingredients.Dequeue();
                    ingredients.Enqueue(left);
                }

                if (freshness.Count == 0)
                {
                    break;
                }

                i = -1;
            }

            if (dishes.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishes.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }

        }
    }
}
