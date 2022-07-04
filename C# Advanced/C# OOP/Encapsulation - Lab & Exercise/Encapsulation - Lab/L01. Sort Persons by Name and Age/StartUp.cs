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
            var persons = new List<Person>();

            for (int i = 0; i < numberOfLines; i++)
            {
                var singleLine = Console.ReadLine()
                    .Split(" ");
                var person = new Person(singleLine[0], singleLine[1], int.Parse(singleLine[2]));
                persons.Add(person);

            }

            var sortedPerson = persons
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.Age);

            foreach (var person in sortedPerson)
            {
                Console.WriteLine(person.ToString());
            }
                
        }
    }
}
