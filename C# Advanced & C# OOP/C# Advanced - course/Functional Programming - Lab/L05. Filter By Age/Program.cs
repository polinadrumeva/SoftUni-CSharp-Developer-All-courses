using System;
using System.Collections.Generic;
using System.Linq;

namespace L05._Filter_by_Age
{
    internal class Program
    {
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

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(", ");
                string name = line[0];
                int age = int.Parse(line[1]);
                Person person = new Person(name, age);
                persons.Add(person);
            }

            var lineType = Console.ReadLine();
            var ageToCompareWith = int.Parse(Console.ReadLine());

            Func<Person, bool> funcAgeCompare = p => true;
            if (lineType == "younger")
            {
                funcAgeCompare = p => p.Age < ageToCompareWith;
            }
            else if (lineType == "older")
            {
                funcAgeCompare = p => p.Age >= ageToCompareWith;
            }

            var typeToPrint = Console.ReadLine();
            Func<Person, string> funcPrintResult = p => p.Name + " " + p.Age;

            if (typeToPrint == "name age")
            {
                funcPrintResult = p => (p.Name + " - " + p.Age);
            }
            else if (typeToPrint == "name")
            {
                funcPrintResult = p => p.Name;
            }
            else if (typeToPrint == "age")
            {
                funcPrintResult = p => p.Age.ToString();
            }

            var filtredPeople = persons.Where(funcAgeCompare).Select(funcPrintResult);
            foreach (var item in filtredPeople)
            {
                Console.WriteLine(item);
            }
        }
    }
}
