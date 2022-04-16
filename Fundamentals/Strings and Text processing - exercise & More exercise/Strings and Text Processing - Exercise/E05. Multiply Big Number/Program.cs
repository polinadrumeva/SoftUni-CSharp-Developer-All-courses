using System;
using System.Collections.Generic;

namespace E05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            if (secondNumber == 0)
            {
                Console.WriteLine("0");
                return;
            }

            char[] bigNumber = firstNumber.ToCharArray();

            List<string> result = new List<string>();
            int miniResult = 0;
            for (int i = bigNumber.Length -1; i >= 0; i--)
            {
               miniResult = (int.Parse(bigNumber[i].ToString()) * secondNumber) + miniResult;
               result.Insert(0, (miniResult % 10).ToString());
               miniResult /= 10;
            }
            if (miniResult != 0)
            {
                result.Insert(0, miniResult.ToString());
            }

            Console.WriteLine(String.Join("", result));
        }
    }
}
