using System;
using System.Collections.Generic;
using System.Linq;

namespace E01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> texts = Console.ReadLine().ToList();

            Dictionary<char, int> symbolsWithCount = new Dictionary<char, int>();

            foreach (char text in texts)
            {
                if (text == ' ')
                {
                    continue;
                }
                else if (symbolsWithCount.ContainsKey(text))
                {
                    symbolsWithCount[text]++;
                }
                else
                {
                    symbolsWithCount.Add(text, 1);
                }
            }

            foreach (var item in symbolsWithCount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
