using Footballers.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class CoachDTO
    {
        [StringLength(40, MinimumLength = 2)]
        [Required]
        [XmlElement("Name")]
        public string? Name { get; set; }

        [Required]
        [XmlElement("Nationality")]
        public string? Nationality { get; set; }

        [XmlArray("Footballers")]
        public virtual FoolballerDTO[] Footballers { get; set; } 
    }
}
