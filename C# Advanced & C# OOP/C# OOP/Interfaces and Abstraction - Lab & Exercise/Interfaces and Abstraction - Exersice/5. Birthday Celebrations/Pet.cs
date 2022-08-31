using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public class Pet : IBirthday
    {
        public string Name { get; set; }
        public string BirthdayDate { get; set; }

        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.BirthdayDate = birthday;
        }
    }
}
