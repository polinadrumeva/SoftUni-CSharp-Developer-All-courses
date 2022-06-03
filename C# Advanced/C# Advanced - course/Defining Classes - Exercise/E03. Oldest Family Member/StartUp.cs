using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();   

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string name = command.Split(" ")[0];
                int age = int.Parse(command.Split(" ")[1]);
                Person person = new Person(name, age);
                family.AddMember(person);
            }
            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
