using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class SupplierDTO
    {
        public string Name { get; set; } = null!;

        public bool IsImporter { get; set; }
    }
}
