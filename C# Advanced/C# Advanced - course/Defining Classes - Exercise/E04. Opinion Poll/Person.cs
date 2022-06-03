using System;
using System.Collections.Generic;
using System.Text;

namespace E04._Opinion_Poll
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }


        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }
        public Person(int age)
        {
            this.name = "No name";
            this.age = age;
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
