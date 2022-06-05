using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.OpinionPoll
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();
                string name = data.Split(" ")[0];
                int age = int.Parse(data.Split(" ")[1]);
                Person person = new Person(name, age);
                people.Add(person);
            }

            foreach (var person in people.Where(person => person.Age > 30).OrderBy(person => person.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
