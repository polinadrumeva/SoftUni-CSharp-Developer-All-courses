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
                var singleLine = Console.ReadLine().Split(" ");
                try
                {
                    var person = new Person(singleLine[0], singleLine[1], int.Parse(singleLine[2]), decimal.Parse(singleLine[3]));

                    persons.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            decimal percentage = decimal.Parse(Console.ReadLine());

            foreach (var person in persons)
            {
                Console.WriteLine($"{person.ToString()}");
            }


        }

    }
}