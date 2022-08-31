using System;
using System.Collections.Generic;
using System.Text;

namespace E09._SoftUni_Exam_Results
{
    internal class Students
    {
        public string Name { get; set; }
        public Dictionary<string, int> ContestsResult { get; set; }
        public int TotalPoints  { get; set; }

        public Students(string name)
        {
            this.Name = name;
            this.ContestsResult = new Dictionary<string,int>();
        }
    
    }
}
