using System;
using System.Collections.Generic;

namespace L05._Stack_of_Strings
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            var list = new List<string> { "1", "2", "3" };
            stack.AddRange(list);
            Console.WriteLine(stack.IsEmpty());

        }
    }
}
