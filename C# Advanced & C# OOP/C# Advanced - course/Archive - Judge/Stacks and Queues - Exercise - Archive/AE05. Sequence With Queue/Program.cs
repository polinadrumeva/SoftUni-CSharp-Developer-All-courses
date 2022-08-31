using System;
using System.Collections.Generic;
using System.Numerics;

namespace AE05._Sequence_With_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int members = 18;
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            Queue<BigInteger> numbers = new Queue<BigInteger>();
            Queue<BigInteger> numbersForPrint = new Queue<BigInteger>();

            numbers.Enqueue(number);
            numbersForPrint.Enqueue(number);

            for (int i = 0; i < members; i++)
            {
                numbers.Enqueue(numbers.Peek() + 1);
                numbersForPrint.Enqueue(numbers.Peek() + 1);
                numbers.Enqueue((numbers.Peek() * 2) + 1);
                numbersForPrint.Enqueue((numbers.Peek() * 2) + 1);
                numbers.Enqueue(numbers.Peek() + 2);
                numbersForPrint.Enqueue(numbers.Peek() + 2);
                numbers.Dequeue();

            }

            int count = 0;
            foreach (var item in numbersForPrint)
            {
                Console.Write($"{item} ");
                count++;
                if (count == 50)
                {
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
