using System;
using System.Collections.Generic;
using System.Linq;

namespace E02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lengthNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            HashSet<double> numbers = new HashSet<double>();
            HashSet<double> dublicateNumbers = new HashSet<double>();

            int first = lengthNumbers[0];
            int second = lengthNumbers[1];

            for (int i = 0; i < first; i++)
            {
                double num = double.Parse(Console.ReadLine());
                numbers.Add(num);
            }

            for (int j = 0; j < second; j++)
            {
                double number = double.Parse(Console.ReadLine());
                if (numbers.Contains(number))
                {
                    dublicateNumbers.Add(number);
                }
            }


            foreach (var item in dublicateNumbers)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

        }
    }
}
