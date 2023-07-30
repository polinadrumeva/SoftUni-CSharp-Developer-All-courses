using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class ImportClientAddressDto
    {
        [Required]
        [StringLength(20, MinimumLength = 10)]
        [XmlElement("StreetName")]
        public string StreetName { get; set; } 

        [Required]
        [XmlElement("StreetNumber")]
        public int StreetNumber { get; set; }

        [Required]
        [XmlElement("PostCode")]
        public string PostCode { get; set; } 

        [Required]
        [XmlElement("City")]
        [StringLength(15, MinimumLength = 5)]
        public string City { get; set; } 

        [Required]
        [XmlElement("Country")]
        [StringLength(15, MinimumLength = 5)]
        public string Country { get; set; } 
    }
}
