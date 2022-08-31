using System;
using System.Collections.Generic;
using System.Linq;

namespace AL01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbersArr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Dictionary<double, int> numbers = new Dictionary<double, int>();

            for (int i = 0; i < numbersArr.Length; i++)
            {
                if (!numbers.ContainsKey(numbersArr[i]))
                {
                    numbers.Add(numbersArr[i], 1);
                }
                else
                {
                    numbers[numbersArr[i]] += 1;
                }
            
            }

            foreach (var item in numbers)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
