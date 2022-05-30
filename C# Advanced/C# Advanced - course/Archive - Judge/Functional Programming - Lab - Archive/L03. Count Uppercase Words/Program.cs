using System;
using System.Linq;

namespace AL03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsUpper(x[0]));

            Console.WriteLine(string.Join("\n", line));

            //, '.','!','?',';',':'
        }
    }
}
