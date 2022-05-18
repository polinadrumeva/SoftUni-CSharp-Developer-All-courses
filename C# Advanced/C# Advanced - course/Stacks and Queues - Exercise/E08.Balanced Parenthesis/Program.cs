using System;
using System.Collections.Generic;

namespace E08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            Stack<char> stack = new Stack<char>(sequence);

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '(')
                {
                    stack.Push(sequence[i]);
                }
                else if (sequence[i] == ')')
                {
                    int startIndex = stack.Pop();
                    Console.WriteLine(sequence.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
