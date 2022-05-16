using System;
using System.Collections.Generic;

namespace AL01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversedText = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                reversedText.Push(input[i]);
            }

            foreach (var item in reversedText)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
