using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public string Name { get; set; }
        public int Age 
        { 
            get 
            {
                return this.age; 
            } 
            set
            {
                if (value > 0)
                {
                    this.age = value;
                }
                else
                {
                    this.age = 0;
                }
                
            } 
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
