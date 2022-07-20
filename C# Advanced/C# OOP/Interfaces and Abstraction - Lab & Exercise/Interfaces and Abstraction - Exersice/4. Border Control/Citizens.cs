using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizens : ISociety
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public Citizens(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
    }
}
