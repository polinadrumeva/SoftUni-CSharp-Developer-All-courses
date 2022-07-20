namespace ExplicitInterfaces
{
    using System;
    using ExplicitInterfaces.Models.Interfaces;
    using ExplicitInterfaces.Models;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> all = new List<Citizen>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ');
                IPerson citizen = new Citizen(cmdArgs[0], int.Parse(cmdArgs[2]), cmdArgs[1]);
                IResident citizen1 = new Citizen(cmdArgs[0], int.Parse(cmdArgs[2]), cmdArgs[1]);

                citizen.GetName();
                citizen1.GetName();

            }
        }
    }
}
