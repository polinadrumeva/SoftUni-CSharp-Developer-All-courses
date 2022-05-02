using System;
using System.Collections.Generic;
using System.Text;

namespace L01._Sort_Persons_by_Name_and_Age
{
    public class Person
    {
        private string firstName; 
        private string lastName;
        private int age;
        private decimal salary;

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                firstName = value;
            }

        }
        public string LastName
        {
            get => lastName;
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                lastName = value;
            }
        }
        public int Age 
        {
            get => age;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be zero or a negative integer!");
                    
                }

                age = value;
            }
        }

        public decimal Salary 
        { 
            get => salary;
            private set
            {
                if (value < 460)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be less than 650 leva!");
                }

                salary = value;
            }
        }

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

            this.Salary *= 1 + percentage / 100;
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary} leva.";
        }
    }
}
