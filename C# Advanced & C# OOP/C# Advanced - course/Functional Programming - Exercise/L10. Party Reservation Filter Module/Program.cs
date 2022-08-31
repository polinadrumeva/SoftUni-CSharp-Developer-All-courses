using System;
using System.Collections.Generic;
using System.Linq;

namespace E10._Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            List<string> leftGuests = new List<string>();
            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                Predicate<string> predicate = GetPredicate(command);
                string[] cmdArg = command.Split(';');
                switch (cmdArg[0])
                {
                    case "Add filter":
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (predicate(people[i]))
                            {
                                leftGuests.Add(people[i]);
                                people.Remove(people[i]);
                                i = -1;
                            }
                        }
                        break;
                    case "Remove filter":
                        for (int i = 0; i < leftGuests.Count; i++)
                        {
                            if (predicate(leftGuests[i]))
                            {
                                people.Insert(0, leftGuests[i]);
                                leftGuests.Remove(leftGuests[i]);
                                i -= 1;
                            }
                        }
                        break;

                }
            }

            Console.WriteLine(string.Join(" ", people));
        }

        private static Predicate<string> GetPredicate(string command)
        {

            string filterType = command.Split(';')[1];
            string parameter = command.Split(';')[2];

            Predicate<string> predicate = null;
            if (filterType == "Starts with")
            {
                predicate = name => name.StartsWith(parameter);
            }
            else if (filterType == "Ends with")
            {
                predicate = name => name.EndsWith(parameter);
            }
            else if (filterType == "Length")
            {
                predicate = name => name.Length == int.Parse(parameter);
            }
            else if (filterType == "Contains")
            {
                predicate = name => name.Contains(parameter);
            }
            return predicate;
        }
    }
}
