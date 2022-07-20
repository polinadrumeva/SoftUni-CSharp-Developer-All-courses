using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISociety> all = new List<ISociety>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArg = command.Split(" ");
                if (cmdArg.Length == 2)
                {

                    ISociety newRobot = new Robots(cmdArg[0], cmdArg[1]);
                    all.Add(newRobot);
                    
                }
                else
                {
                    ISociety newHuman = new Citizens(cmdArg[0], int.Parse(cmdArg[1]), cmdArg[2]);
                    all.Add(newHuman);
                }

            }

            var fakeId = Console.ReadLine();
            all.Where(c => c.Id.EndsWith(fakeId))
            .Select(c => c.Id)
            .ToList()
            .ForEach(Console.WriteLine);
        }
    }
}
