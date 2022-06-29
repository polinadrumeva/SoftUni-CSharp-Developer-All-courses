using System;
using System.IO;

namespace L02._Line_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using StreamReader text = new StreamReader("input.txt");
            using StreamWriter output = new StreamWriter("output.txt");
            int number = 1;

            while (!text.EndOfStream)
            {
                var line = text.ReadLine();
                output.WriteLine($"{number}. {line}");

                number++;
            }
        }
    }
}
