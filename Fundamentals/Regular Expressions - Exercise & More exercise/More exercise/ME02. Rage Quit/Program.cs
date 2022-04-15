using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ME02._Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            StringBuilder resultTxt = new StringBuilder();

            string digitsPattern = @"(([^\d]+)(\d+))";

            MatchCollection maches = Regex.Matches(command, digitsPattern);
            foreach (Match m in maches)
            {
                string forRepeat = m.Groups[2].Value;
                int countRepeat = int.Parse(m.Groups[3].Value);
                if (countRepeat == 0)
                {
                    continue;
                }
                else
                {
                    while (countRepeat > 0)
                    {
                        resultTxt.Append(forRepeat.ToUpper());
                        countRepeat--;
                    }
                }

            }
                int count = 0;
                int countUniqueDigits = 0;
                string result = resultTxt.ToString();
                for (int i = 0; i < result.Length; i++)
                {
                    char searchedSymbol = result[i];
                    result = result.Replace(searchedSymbol, '0');

                    if (searchedSymbol == '0' || char.IsDigit(searchedSymbol))
                    {
                        continue;
                    }
                    if (result.Contains(searchedSymbol))
                    {
                        count++;
                    }
                    else
                    {
                        countUniqueDigits++;
                    }

                    i = -1;
                }

                Console.WriteLine($"Unique symbols used: {countUniqueDigits}");
                Console.WriteLine($"{resultTxt}");
            
        }
    }
}
