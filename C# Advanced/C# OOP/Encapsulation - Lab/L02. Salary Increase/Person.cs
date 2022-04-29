using System;
using System.Collections.Generic;
using System.Text;

namespace L01._Sort_Persons_by_Name_and_Age
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }

        public decimal Salary { get; private set; }

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                percentage /= 2.0M;
            }

            this.Salary *=  1 + percentage / 100;
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary} leva.";
        }
    }
}
