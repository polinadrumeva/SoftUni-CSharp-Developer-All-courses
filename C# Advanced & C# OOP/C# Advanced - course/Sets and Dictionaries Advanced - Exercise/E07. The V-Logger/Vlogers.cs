using System;
using System.Collections.Generic;
using System.Text;

namespace E07._The_V_Logger
{
    public class Vlogers
    {
        public string Name { get; set; }
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }

        public Vlogers(string name)
        {
            this.Name = name;
            this.Followers = new HashSet<string>();
            this.Following = new HashSet<string>();
        }
    }
}
