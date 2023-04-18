using P01_StudentSystem.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {       /*  o	ResourceId
                o	Name – up to 50 characters, unicode
                o	Url – not unicode
                o	ResourceType – enum, can be Video, Presentation, Document or Other
                o	CourseId
            */

        [Key]
        public int ResourceId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public string Url { get; set; } = null!;

        public ResourceType ResourceType { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } 
    }
}
