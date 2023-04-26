using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class PartCarDTO
    {
        public int PartId { get; set; }
        public Part Part { get; set; } = null!;

        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
    }
}
