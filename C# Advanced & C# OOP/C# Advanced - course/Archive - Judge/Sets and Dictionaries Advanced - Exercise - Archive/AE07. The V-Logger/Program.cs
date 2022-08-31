using System;
using System.Collections.Generic;
using System.Linq;

namespace AE07._The_V_Logger
{
    public class Program
    {
        public class Vlogers
        {
            public string Name { get; set; }
            public HashSet<string> Followers { get; set; }
            public HashSet<string> Following { get; set; }

            public Vlogers(string name)
            {
                this.Name = name;
                this.Followers = new HashSet<string>();
                this.Following = new HashSet<string>();
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, Vlogers> vlogers = new Dictionary<string, Vlogers>();
            int count = 0;
            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] data = command.Split(" ");
                string name = data[0];
                if (data.Length == 4)
                {
                    if (!vlogers.ContainsKey(name))
                    {
                        vlogers.Add(name, new Vlogers(name));
                        count++;

                    }
                }
                else if (data.Length == 3)
                {
                    string secondVloger = data[2];
                    if (name != secondVloger && vlogers.ContainsKey(name) && vlogers.ContainsKey(secondVloger))
                    {
                        if (!vlogers[name].Following.Contains(secondVloger))
                        {
                            vlogers[secondVloger].Followers.Add(name);
                            vlogers[name].Following.Add(secondVloger);
                        }

                    }
                }

            }

            int mostFamousVloger = 0;
            int countOfVlogers = 1;
            Console.WriteLine($"The V-Logger has a total of {count} vloggers in its logs.");
            foreach (var vloger in vlogers.OrderByDescending(x => x.Value.Followers.Count()).ThenBy(x => x.Value.Following.Count()))
            {
                Console.WriteLine($"{countOfVlogers}. {vloger.Key} : {vloger.Value.Followers.Count} followers, {vloger.Value.Following.Count} following");
                mostFamousVloger++;
                if (mostFamousVloger == 1)
                {
                    foreach (var follower in vloger.Value.Followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }

                }

                countOfVlogers++;
            }
        }
    }
}
