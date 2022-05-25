using System;
using System.Collections.Generic;

namespace E06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] colorsTheme = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = colorsTheme[0];
                string[] clothess = colorsTheme[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothess.Length; j++)
                {
                    if (!clothes[color].ContainsKey(clothess[j]))
                    {
                        clothes[color].Add(clothess[j], 0);
                    }

                    clothes[color][clothess[j]]++;
                }
            }

            string[] searchedClothes = Console.ReadLine().Split();

            foreach (var item in clothes)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var each in item.Value)
                {
                    if (item.Key == searchedClothes[0] && each.Key == searchedClothes[1])
                    {
                        Console.WriteLine($"* {each.Key} - {each.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {each.Key} - {each.Value}");
                    }
                }
            }
        }
    }
}
