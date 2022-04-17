using System;

namespace ME01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfLines; i++)
            {
                string line = Console.ReadLine();
                int indexesName = line.IndexOf("|") - line.IndexOf("@");
                string name = line.Substring(line.IndexOf("@"), indexesName).Replace("@", "").Trim(); 
                int indexesAge = line.IndexOf("*") - line.IndexOf("#");
                string age = line.Substring(line.IndexOf("#"), indexesAge).Replace("#", "").Trim();

                Console.WriteLine($"{name} is {age} years old.");

            }
        }
    }
}
