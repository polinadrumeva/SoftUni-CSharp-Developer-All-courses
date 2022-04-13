using System;
using System.Text.RegularExpressions;

namespace E06.Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @" [a-z]+[\.\,\-\\_]*\w*\d*\@[a-z]+[\-]*[a-z]*[\.]+[a-z]*[\.]*[a-z]*\b";
            string text = Console.ReadLine();

            MatchCollection macthes = Regex.Matches(text, pattern);

            foreach (Match item in macthes)
            {
                Console.WriteLine(item.Value.Trim());
            }
        }
    }
}
