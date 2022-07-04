using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            Team team = new Team("SoftUni");

            for (int i = 0; i < numberOfLines; i++)
            {
                var singleLine = Console.ReadLine()
                    .Split(" ");
                var person = new Person(singleLine[0], singleLine[1], int.Parse(singleLine[2]), decimal.Parse(singleLine[3]));
                team.AddPlayer(person);
            }
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");


        }

    }
}