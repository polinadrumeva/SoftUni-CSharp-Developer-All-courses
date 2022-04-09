using System;
using System.Collections.Generic;
using System.Linq;

namespace AE03._Maximum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfQueries = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < numOfQueries; i++)
            {
                int[] cmdArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int commandType = cmdArgs[0];
                
                if (commandType == 1)
                {
                    int number = cmdArgs[1];
                    numbers.Push(number);
                }
                else if (commandType == 2)
                { 
                    numbers.Pop();
                }
                else if (commandType == 3)
                {
                    Console.WriteLine(numbers.Max());
                }
                
            }
        }
    }
}
