using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex._01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meal = Console.ReadLine().Split(" ");
            int[] calories = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int count = 0;
            Queue<string> meals = new Queue<string>(meal);
            Stack<int> caloriesStack = new Stack<int>(calories);
            int lastCalories = caloriesStack.Peek();
            int left = 0;

            for (int i = 0; i < meals.Count; i++)
            {
                string currentFood = meals.Peek();
                if (currentFood == "salad")
                {
                    lastCalories -= 350;
                }
                else if (currentFood == "soup")
                {
                    lastCalories -=  490;
                }
                else if (currentFood == "pasta")
                {
                    lastCalories -= 680;
                }
                else if (currentFood == "steak")
                {
                    lastCalories -= 790;
                }
                count++;
                meals.Dequeue();
                i = -1;
                if (lastCalories <= 0)
                {
                    caloriesStack.Pop();
                    if (caloriesStack.Count == 0)
                    {
                        break;
                    }
                    left = Math.Abs(lastCalories);
                    lastCalories = caloriesStack.Peek() - left;
                    
                    
                }
                
                if (meals.Count == 0)
                {
                    caloriesStack.Pop();
                    caloriesStack.Push(lastCalories);
                    Console.WriteLine($"John had {count} meals.");
                    Console.WriteLine($"For the next few days, he can eat {string.Join(", ",caloriesStack)} calories.");
                }
               
            }

            if (caloriesStack.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }

        }
    }
}
