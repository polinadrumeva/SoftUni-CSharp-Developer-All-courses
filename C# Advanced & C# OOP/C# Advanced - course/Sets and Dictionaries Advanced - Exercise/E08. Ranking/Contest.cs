using System;
using System.Collections.Generic;
using System.Text;

namespace E08._Ranking
{
    internal class Contest
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public Contest(string name, string password)
        {
            this.Name = name;
            this.Password = password; 
        }
    }
}
