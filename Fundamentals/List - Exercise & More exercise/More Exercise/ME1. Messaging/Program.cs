using System;
using System.Collections.Generic;
using System.Linq;

namespace ME1._Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
           List<char> strings = Console.ReadLine().ToList();
            int currentNum = 0;
            int sumOfEachDigits = 0;
            string message = string.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                currentNum = numbers[i];
                while (currentNum != 0)
                {
                    sumOfEachDigits += currentNum % 10;
                    currentNum /= 10;
                }
                while (sumOfEachDigits > strings.Count)
                {
                    sumOfEachDigits += sumOfEachDigits % 10;
                    sumOfEachDigits /= 10;
                }
                //for (int k = 0; k < strings.Count; k++)
                //{
                //    if (sumOfEachDigits == k)
                //    {
                //        message += strings[k];
                //        strings.RemoveAt(k);
                //    }
                //}
                message += strings.ElementAt(sumOfEachDigits);
                strings.RemoveAt(sumOfEachDigits);

                sumOfEachDigits = 0;
            }

            Console.WriteLine(message);
        }
    }
}
