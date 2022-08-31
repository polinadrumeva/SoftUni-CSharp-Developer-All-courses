using System;
using System.Collections.Generic;
using System.Text;

namespace E08._Ranking
{
    internal class Students
    {
        public string Username { get; set; }
        public Dictionary<string, int> Contest { get; set; }

        public int TotalPoints { get; set; }

        public Students(string username)
        {
            this.Username = username;
            this.Contest = new Dictionary<string, int>();
        }
    }
}
