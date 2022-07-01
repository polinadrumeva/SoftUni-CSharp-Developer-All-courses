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
                return this.Age; 
            } 
            set
            {
                if (value >= 0)
                {
                    this.Age = value;
                }
                
            } 
        }
    }
}
