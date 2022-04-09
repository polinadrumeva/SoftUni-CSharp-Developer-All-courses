using System;
using System.Collections.Generic;
using System.Linq;

namespace ME04._Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dwarfs = new Dictionary<string, Dictionary<string, int>>();

            string text;
            while ((text = Console.ReadLine()) != "Once upon a time")
            {
                string[] textArr = text.Split("<:>", StringSplitOptions.RemoveEmptyEntries);
                string name = textArr[0].TrimStart().TrimEnd();
                string hatColor = textArr[1].TrimStart().TrimEnd(); ;
                int physics = int.Parse(textArr[2].TrimStart().TrimEnd());

                if (dwarfs.ContainsKey(hatColor))
                {
                    if (dwarfs[hatColor].ContainsKey(name))
                    {
                        if (dwarfs[hatColor][name] < physics)
                        {
                            dwarfs[hatColor][name] = physics;
                        }
                    }
                    else
                    {
                        dwarfs[hatColor].Add(name, physics);
                    }
                }
                else
                {
                    dwarfs.Add(hatColor, new Dictionary<string, int>());
                    dwarfs[hatColor].Add(name, physics);
                }

            }

            foreach (var item in dwarfs.OrderByDescending(x => x.Value.Values.Max()).ThenByDescending(x => x.Key))
            {

                foreach (var im in item.Value)
                {
                    Console.WriteLine($"({item.Key}) {im.Key} <-> {im.Value}");
                }

            }
        }
    }
}

