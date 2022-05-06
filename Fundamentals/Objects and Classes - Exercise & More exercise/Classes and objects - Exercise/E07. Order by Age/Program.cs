using System;
using System.Collections.Generic;
using System.Linq;

namespace E07._Order_by_Age
{
    class ID
    {
        public string Name { get; set; }

        public string IDnumber { get; set; }

        public int Age { get; set; }

        public ID(string name, string idNumber, int age)
        {
            this.Name = name;
            this.IDnumber = idNumber;
            this.Age = age;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<ID> Idnumbers = new List<ID>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commands = command.Split();
                string name = commands[0];
                string idNumber = commands[1];
                int age = int.Parse(commands[2]);
                ID newPerson = new ID(name, idNumber, age);

                if (newPerson.IDnumber == idNumber)
                {
                    newPerson.Name = name;
                    newPerson.Age = age;
                }
                  
                Idnumbers.Add(newPerson);
              
                command = Console.ReadLine();
            }
           
            Idnumbers = Idnumbers.OrderBy(newPerson => newPerson.Age).ToList();
            foreach (ID newPerson in Idnumbers)
            {
                Console.WriteLine($"{newPerson.Name} with ID: {newPerson.IDnumber} is {newPerson.Age} years old.");
            }
        }
    }
}
