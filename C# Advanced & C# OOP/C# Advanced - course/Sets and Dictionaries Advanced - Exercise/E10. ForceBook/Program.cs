using System;
using System.Collections.Generic;
using System.Linq;

namespace E01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> forceSides = new Dictionary<string, HashSet<string>>();
            List<string> sides = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                if (command.Contains('|'))
                {
                    string[] cmdArg = command.Split(" | ");
                    string forseSide = cmdArg[0];
                    if (!forceSides.ContainsKey(forseSide))
                    {
                        forceSides.Add(forseSide, new HashSet<string>());
                        sides.Add(forseSide);
                    }

                    string forseUser = cmdArg[1];
                    if (!forceSides[forseSide].Contains(forseUser))
                    {
                        forceSides[forseSide].Add(forseUser);
                    }
                }
                else if (command.Contains('>'))
                {
                    string[] cmdArg = command.Split(" -> ");
                    string forseUserChange = cmdArg[0];
                    string forseSideChange = cmdArg[1];

                    if (sides[0] != forseSideChange && forceSides.ContainsKey(sides[0]))
                    {
                        forceSides[sides[0]].Remove(forseUserChange);
                        forceSides[forseSideChange].Add(forseUserChange);
                        Console.WriteLine($"{forseUserChange} joins the {forseSideChange} side!");
                    }
                    else if (sides[1] != forseSideChange && forceSides.ContainsKey(sides[1]))
                    {
                        forceSides[sides[1]].Remove(forseUserChange);
                        forceSides[forseSideChange].Add(forseUserChange);
                        Console.WriteLine($"{forseUserChange} joins the {forseSideChange} side!");
                    }
                    else if (!forceSides.ContainsKey(sides[0]) || !forceSides.ContainsKey(sides[1]))
                    {
                        forceSides[forseSideChange].Add(forseUserChange);
                        Console.WriteLine($"{forseUserChange} joins the {forseSideChange} side!");
                    }
                }
                   
            }

            foreach (var side in forceSides.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (!(side.Value.Count == 0))
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    foreach (var member in side.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {member}");
                    }
                }
            }
        }
    }
}
