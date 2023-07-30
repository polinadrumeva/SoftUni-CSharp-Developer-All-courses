using Invoices.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Invoice")]
    public class ExportClientInvoicesDto
    {
        [Required]
        [XmlElement("InvoiceNumber")]
        [Range(1000000000, 1500000000)]
        public int Number { get; set; }

       
        [Required]
        [XmlElement("DueDate")]
        public DateTime DueDate { get; set; }

        [Required]
        [XmlElement("IssueDate")]
        public DateTime IssueDate { get; set; }

        [Required]
        [XmlElement("Amount")]
        public decimal Amount { get; set; }

        [Required]
        [XmlElement("Currency")]
        public CurrencyType CurrencyType { get; set; }
    }
}
