using System;
using System.Collections.Generic;
using System.Linq;

namespace ME02._Oldest_Family_Member
{
    class Family
    {
        public List<Person> family { get; set; }

        public Family(List<Person> family)
        {
            this.family = new List<Person>();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        { 
            this.Name = name;
            this.Age = age;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> family = new List<Person>();
            int numberOfPerson = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPerson; i++)
            {
                string persons = Console.ReadLine();
                string[] personInformation = persons.Split();
                string name = personInformation[0];
                int age = int.Parse(personInformation[1]);

                Person newPerson = new Person(name, age);   
                family.Add(newPerson);
            }

            family = family.OrderByDescending(newPerson => newPerson.Age).ToList();
            foreach (Person newPerson in family)
            {
                Console.WriteLine($"{newPerson.Name} {newPerson.Age}");
                break;
            }
        }
    }
}

