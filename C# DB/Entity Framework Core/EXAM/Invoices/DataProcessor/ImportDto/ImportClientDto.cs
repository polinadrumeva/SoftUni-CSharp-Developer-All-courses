using Invoices.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportClientDto
    {
        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(15)]
        [XmlElement("NumberVat")]
        public string NumberVat { get; set; }

        [XmlArray("Addresses")]
        public ImportClientAddressDto[] Addresses { get; set; }
    }
}
