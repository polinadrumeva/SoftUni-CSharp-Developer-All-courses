using System;
using System.Collections.Generic;
using System.Linq;

namespace AL03._Decimal_to_Binary_Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            if (decimalNumber == 0)
            {
                Console.WriteLine(decimalNumber);
                return;
            }

            Stack<int> binaryNumber = new Stack<int>();

            while (decimalNumber != 0)
            {
                int diff = decimalNumber % 2;
                binaryNumber.Push(diff);
                decimalNumber /= 2;
            }

            binaryNumber.Reverse();

            foreach (var item in binaryNumber)
            {
                Console.Write(item);
            }

            Console.WriteLine();
        }
    }
}
