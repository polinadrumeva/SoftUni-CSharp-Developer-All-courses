using Footballers.Data.Models.Enums;
using Footballers.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Foolballer")]
    public class FoolballerDTO
    {
        [StringLength(40, MinimumLength = 2)]
        [Required]
        [XmlElement("Name")]
        public string? Name { get; set; } 

        [Required]
        [XmlElement("ContractStartDate")]
        public DateTime ContractStartDate { get; set; }

        [Required]
        [XmlElement("ContractEndDate")]
        public DateTime ContractEndDate { get; set; }

        [Required]
        [XmlElement("PositionType")]
        public PositionType PositionType { get; set; }

        [Required]
        [XmlElement("BestSkillType")]
        public BestSkillType BestSkillType { get; set; }


    }
}
