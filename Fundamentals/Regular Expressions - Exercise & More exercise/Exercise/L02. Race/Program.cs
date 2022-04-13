using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace L02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine().Split(", ").ToList();
            string patternName = @"([A-Za-z])+";
            string patternDigits = @"\d";
            Dictionary<string, double> personsData = new Dictionary<string, double>();

            Regex paternName = new Regex(patternName);
            Regex paternDigits = new Regex(patternDigits);

            var name = string.Empty;
            double km = 0;


            string command = Console.ReadLine();

            while (command != "end of race")
            {
               var matchesName = paternName.Matches(command);

                foreach (var item in matchesName)
                {
                    name += item;
                }
                
                if (!personsData.ContainsKey(name))
                {
                    personsData.Add(name, 0);
                }

                var matchesDigits = paternDigits.Matches(command);

                foreach (var items in matchesDigits)
                {
                    km += double.Parse(items.ToString());
                }

                if (personsData.ContainsKey(name))
                {
                    personsData[name] += km;
                }

                command = Console.ReadLine();

                name = String.Empty;
                km = 0;
            }

            Dictionary<string, double> persons = new Dictionary<string, double>();
            foreach (var item in personsData)
            {
                if (participants.Contains(item.Key))
                {
                    persons.Add(item.Key, item.Value);
                }
            }

            int count = 0;
            foreach (var item in persons.OrderByDescending(x => x.Value))
            {
                count++;
                if (count ==1)
                {
                    Console.WriteLine($"1st place: {item.Key}");
                }
                else if (count == 2)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                }
                else if (count == 3)
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                }
                else
                {
                    break;
                }
            }


        }
    }
}
