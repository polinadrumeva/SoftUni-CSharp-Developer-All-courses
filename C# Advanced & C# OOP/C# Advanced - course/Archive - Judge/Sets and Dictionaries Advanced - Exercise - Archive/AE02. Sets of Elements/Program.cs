using System;
using System.Collections.Generic;
using System.Linq;

namespace AE02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lengthNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int first = lengthNumbers[0];
            int second = lengthNumbers[1];
            double[] numbersFirst = new double[first];
            double[] numbersSecond = new double[second];
            HashSet<double> duplicateNumbers = new HashSet<double>();

            for (int i = 0; i < numbersFirst.Length; i++)
            {
                double num = double.Parse(Console.ReadLine());
                numbersFirst[i] = num;
            }
            for (int j = 0; j < numbersSecond.Length; j++)
            {
                double num = double.Parse(Console.ReadLine());
                numbersSecond[j] = num;
            }


            for (int i = 0; i < numbersFirst.Length; i++)
            {
                for (int j = 0; j < numbersSecond.Length; j++)
                {
                    if (numbersFirst[i] == numbersSecond[j])
                    {
                        duplicateNumbers.Add(numbersFirst[i]);
                    }
                }
            }

            foreach (var item in duplicateNumbers)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

        }
    }
}
