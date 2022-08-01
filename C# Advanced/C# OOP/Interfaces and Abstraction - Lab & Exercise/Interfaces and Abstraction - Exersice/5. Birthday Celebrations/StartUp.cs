using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthday> all = new List<IBirthday>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArg = command.Split(" ");
                if (cmdArg[0] == "Citizen")
                {

                    IBirthday newCitizen = new Citizens(cmdArg[1], int.Parse(cmdArg[2]), cmdArg[3], cmdArg[4]);
                    all.Add(newCitizen);

                }
                else if (cmdArg[0] == "Pet")
                {
                    IBirthday newPet = new Pet(cmdArg[1], cmdArg[2]);
                    all.Add(newPet);
                }

            }

            var year = Console.ReadLine();
            
            foreach (var item in all.Where(c => c.BirthdayDate.EndsWith(year)).Select(c => c.BirthdayDate))
            {
                Console.WriteLine(item);
            }


            
        }
    }
}
