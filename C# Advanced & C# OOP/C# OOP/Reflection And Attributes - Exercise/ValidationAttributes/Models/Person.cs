namespace ValidationAttributes.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ValidationAttributes.Utilities;

    public class Person
    {
        private string fullName;
        private int age;

        [MyRequired]
        public string FullName { get; set; }

        [MyRange(12, 90)]
        public int Age { get; set; }

        public Person(string fullname, int age)
        {
            this.FullName = fullname;
            this.Age = age;
        }
    }
}
