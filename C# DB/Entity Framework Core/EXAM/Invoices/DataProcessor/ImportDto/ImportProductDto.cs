using Invoices.Data.Models;
using Invoices.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(5.00, 1000.00)]
        public decimal Price { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; } 

        public int[] Clients { get; set; } = null!;
    }
}
