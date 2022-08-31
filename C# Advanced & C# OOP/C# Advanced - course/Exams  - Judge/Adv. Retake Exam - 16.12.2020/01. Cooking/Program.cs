using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sequenceLiquids = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] sequenceIngredients = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> liquids = new Queue<int>(sequenceLiquids);
            Stack<int> ingredients = new Stack<int>(sequenceIngredients);

            Dictionary<string, int> foods = new Dictionary<string, int>();
            foods.Add("Bread", 0);
            foods.Add("Cake", 0);
            foods.Add("Pastry", 0);
            foods.Add("Fruit Pie", 0);

            for (int  i = 0; i < liquids.Count; i++)
            {
                int sum = liquids.Peek() + ingredients.Peek();
                if (sum == 25)
                {
                    foods["Bread"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sum == 50)
                {
                    foods["Cake"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sum == 75)
                {
                    foods["Pastry"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sum == 100)
                {
                    foods["Fruit Pie"]++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    int left = ingredients.Peek() + 3;
                    ingredients.Pop();
                    ingredients.Push(left);
                }
                if (ingredients.Count == 0)
                {
                    break;
                }

                i = -1;
            }

            if (foods.Sum(x => x.Value) < 4)
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            else
            {
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
                
            }
            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            foreach (var food in foods.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
