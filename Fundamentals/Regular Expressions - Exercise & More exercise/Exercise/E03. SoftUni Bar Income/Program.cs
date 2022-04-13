using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace E03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]*)%[^|$%.]*?<(?<product>\w+)>[^|$%.]*?\|(?<count>\d+)\|[^|$%.]*?(?<price>[0-9]+(\.[0-9]+)?)\$";
           
            Regex regex = new Regex(pattern);
            double totalPrice = 0;
            
            string command;
            while ((command = Console.ReadLine()) != "end of shift")
            {
                if (regex.IsMatch(command))
                {
                    MatchCollection matches = regex.Matches(command);
                    foreach (Match item in matches)
                    {
                        string name = item.Groups["name"].Value;
                        string product = item.Groups["product"].Value;
                        int count = int.Parse(item.Groups["count"].Value);
                        double price = double.Parse(item.Groups["price"].Value);
                        double currentPrice = count * price;

                        totalPrice += currentPrice;
                        Console.WriteLine($"{name}: {product} - {currentPrice:f2}");
                    }
                }
            }

            Console.WriteLine($"Total income: {totalPrice:f2}");

            
        }
    }
}
