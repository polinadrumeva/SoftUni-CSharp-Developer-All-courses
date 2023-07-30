using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class ExportClientDto
    {
        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        [XmlElement("ClientName")]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(15)]
        [XmlElement("VatNumber")]
        public string NumberVat { get; set; }

        [XmlAttribute("InvoicesCount")]
        public int InvoicesCount { get; set; }

        [XmlArray("Invoices")]
        public ExportClientInvoicesDto[] Invoices { get; set; } = null!;
    }
}
