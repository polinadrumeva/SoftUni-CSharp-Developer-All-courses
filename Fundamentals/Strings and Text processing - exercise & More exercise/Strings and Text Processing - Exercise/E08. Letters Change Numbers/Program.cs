using System;
using System.Linq;

namespace E08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            decimal sum = 0;

            foreach (string word in sequence)
            {
                sum += CalculateSum(word);
            }

            Console.WriteLine($"{sum:f2}");
           
        }
        static decimal CalculateSum(string word)
        { 
           decimal sum = 0; 
            
            char firstLetter = word[0];
            char lastLetter = word[word.Length - 1];
            int number = int.Parse(word.Substring(1, word.Length - 2));

            int firstPosition = GetAplphabetPosition(firstLetter);
            int lastPosition = GetAplphabetPosition(lastLetter);

            if (char.IsUpper(firstLetter))
            {
                sum = (decimal)number / firstPosition;
            }
            else if (char.IsLower(firstLetter))
            { 
                sum = (decimal) number * firstPosition;
            }

            if (char.IsUpper(lastLetter))
            {
                sum -= lastPosition;
            }
            else if (char.IsLower(lastLetter))
            {
                sum += lastPosition;
            }

            return sum;
        }

        static int GetAplphabetPosition(char symbol)
        {
            if (!char.IsLetter(symbol))
            {
                return -1;
            }

            char symbolCI = char.ToLowerInvariant(symbol);

            return (int)symbolCI - 96;
        }
    }
}
