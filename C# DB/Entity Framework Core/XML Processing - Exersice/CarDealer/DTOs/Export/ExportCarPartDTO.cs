using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("part")]
    public class ExportCarPartDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("price")]
        public decimal Price { get; set; }

      
    }
}
