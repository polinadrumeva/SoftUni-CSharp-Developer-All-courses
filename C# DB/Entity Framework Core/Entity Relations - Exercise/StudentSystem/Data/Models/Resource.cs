using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string ResourceType  { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }

}
