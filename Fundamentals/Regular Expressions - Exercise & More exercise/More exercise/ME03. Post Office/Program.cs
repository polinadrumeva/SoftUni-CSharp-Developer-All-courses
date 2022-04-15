using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ME03._Post_Office
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split("|").ToList();
            Dictionary<char, List<int>> capLettersAndLenghWord = new Dictionary<char, List<int>>();

            string capitalLetterPattern = @"([\#\$\%\*\&])(?<capLetter>[A-Z]+)\1";
            Match machesLetter = Regex.Match(text[0], capitalLetterPattern);
            string capitalLetter = machesLetter.Groups["capLetter"].Value;
            for (int i = 0; i < capitalLetter.Length; i++)
            {
                capLettersAndLenghWord.Add(capitalLetter[i], new List<int>());
                capLettersAndLenghWord[capitalLetter[i]].Add((int)capitalLetter[i]);
            }

            string digitsPattern = @"\d+\:(\d{2})";
            MatchCollection machesDigits = Regex.Matches(text[1], digitsPattern);

            foreach (Match match in machesDigits)
            {
                string currentMatch = match.Value;
                string[] currMatch = currentMatch.Split(":");
                char symbol = (char)(int.Parse(currMatch[0]));

                if (capLettersAndLenghWord.ContainsKey(symbol))
                {
                    capLettersAndLenghWord[symbol].Add(int.Parse(currMatch[1]) + 1);
                }
            }

            string[] thirdLine = text[2].Split(" ");
            List<string> words = new List<string>();

            for (int i = 0; i < thirdLine.Length; i++)
            {
                char symbolFirst = thirdLine[i][0];
                foreach (var item in capLettersAndLenghWord)
                {
                    if (item.Key == symbolFirst && item.Value[1] == thirdLine[i].Length)
                    {
                        words.Add(thirdLine[i]);
                    }
                }
            }

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

        }
    }
}
