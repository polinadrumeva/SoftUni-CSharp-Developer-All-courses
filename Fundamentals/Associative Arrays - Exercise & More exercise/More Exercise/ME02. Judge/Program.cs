using System;
using System.Collections.Generic;
using System.Linq;

namespace ME02._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> studentInformation = new Dictionary<string, Dictionary<string,int>>();

            Dictionary<string, int> allStudents = new Dictionary<string, int>();    

            string input;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] inputLine = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string userName = inputLine[0];
                string contest = inputLine[1];
                int points = int.Parse(inputLine[2]);

                if (studentInformation.ContainsKey(contest))
                {
                    if (studentInformation[contest].ContainsKey(userName))
                    {
                        if (studentInformation[contest][userName] < points)
                        {
                            studentInformation[contest][userName] = points;
                            allStudents[userName] = points;
                            continue;
                        }

                    }
                    else
                    {
                        studentInformation[contest].Add(userName, points);
                    }
                }
                else
                {
                    studentInformation.Add(contest, new Dictionary<string, int>());
                    studentInformation[contest].Add(userName, points);
                }

                if (!allStudents.ContainsKey(userName))
                {
                    allStudents.Add(userName, points);
                }
                else
                {
                    allStudents[userName] += points;
                }
            }

            foreach (var item in studentInformation)
            {
                int positions = 1;
                Console.WriteLine($"{item.Key}: {item.Value.Count} participants");
                foreach (var one in item.Value.OrderByDescending(x => x.Value).ThenBy(x=> x.Key))
                {
                    
                    Console.WriteLine($"{positions}. {one.Key} <::> {one.Value}");
                    positions++;
                }
            }

            Console.WriteLine("Individual standings:");
           
            int position = 1;
            foreach (var individual in allStudents.OrderByDescending(x => x.Value).ThenBy(x=> x.Key))
            {
                Console.WriteLine($"{position}. {individual.Key} -> {individual.Value}");
                position++;
            }
        }
    }
}
