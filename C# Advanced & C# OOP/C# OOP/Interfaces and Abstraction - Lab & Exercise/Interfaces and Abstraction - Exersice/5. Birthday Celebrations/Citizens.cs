using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public class Citizens : ISociety, IBirthday
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string BirthdayDate { get; set; }

        public Citizens(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthdayDate = birthday;
        }
    }
}
