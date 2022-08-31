using System;
using System.Collections.Generic;
using System.Linq;

namespace AL02._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> positiveNumbers = new Stack<int>();
            Stack<int> negativeNumbers = new Stack<int>();
            List<string> inputArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            
            positiveNumbers.Push(int.Parse(inputArg[0].ToString()));
                
                for (int k = 1; k < inputArg.Count; k+=2)
                {
                    if (inputArg[k] == "+")
                    {
                        positiveNumbers.Push(int.Parse(inputArg[k+1].ToString()));
                    }
                    else if (inputArg[k] == "-")
                    {
                        negativeNumbers.Push(int.Parse(inputArg[k + 1].ToString()));
                    }
                }

            Console.WriteLine(positiveNumbers.Sum() - negativeNumbers.Sum());
        }
    }
}
