using System;
using System.Linq;

namespace ME02.From_Left_to_the_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You will receive a number that represents how many lines we will get as input.On the next N lines, you will receive a string with 2 numbers separated by a single space. You need to compare them.If the left number is greater than the right number, you need to print the sum of all digits in the left number, otherwise, print the sum of all digits in the right number.

            int numOfLines = int.Parse(Console.ReadLine());
            long sumOfAllDigits = 0;

            for (int i = 0; i < numOfLines; i++)
            {
                string number = Console.ReadLine();
                long[] numbers = number.Split(" ").Select(long.Parse).ToArray();
                for (int k = 0; k < numbers.Length - 1; k++)
                {
                    long firstNum = numbers[k];
                    long secondNum = numbers[k + 1];

                    if (firstNum >= secondNum)
                    {
                        while (firstNum != 0)
                        {
                            sumOfAllDigits += Math.Abs(firstNum) % 10;
                            firstNum /= 10;
                        }
                    }
                    else
                    {
                        while (secondNum != 0)
                        {
                            sumOfAllDigits += Math.Abs(secondNum) % 10;
                            secondNum /= 10;
                        }
                    }
                    Console.WriteLine(sumOfAllDigits);
                    sumOfAllDigits = 0;

                }

            }
        }
    }
}
