using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base (name, age)
        {

            if (age >= 0 && age <= 15)
            {
                this.Age = age;
            }
        }
    }
}
