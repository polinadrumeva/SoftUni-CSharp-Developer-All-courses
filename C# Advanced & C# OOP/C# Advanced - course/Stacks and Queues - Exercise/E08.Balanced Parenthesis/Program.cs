using System;
using System.Collections.Generic;

namespace E08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool areBalance = false;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '(' || sequence[i] == '{' || sequence[i] == '[')
                {
                    stack.Push(sequence[i]);
                }
                else if (sequence[i] == ')' || sequence[i] == '}' || sequence[i] == ']')
                {
                    if (stack.Count == 0)
                    {
                        areBalance = false;
                        break;
                    }

                    char lastElement = stack.Pop();
                    if (lastElement == '(' && sequence[i] == ')')
                    { 
                        areBalance = true;
                    }
                    else if (lastElement == '{' && sequence[i] == '}')
                    {
                        areBalance = true;
                    }
                    else if (lastElement == '[' && sequence[i] == ']')
                    {
                        areBalance = true;
                    }
                    else
                    {
                        areBalance = false;
                        break;
                    }
                }

            }

            if (areBalance)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
