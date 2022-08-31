namespace ExplicitInterfaces.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    public class Citizen : IPerson, IResident
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Country { get; private set; }

        public Citizen(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        void IPerson.GetName()
        {
            Console.WriteLine(this.Name); 
        }

        void IResident.GetName()
        {
            Console.WriteLine($"Mr/Ms/Mrs {this.Name}");
        }
    }
}
