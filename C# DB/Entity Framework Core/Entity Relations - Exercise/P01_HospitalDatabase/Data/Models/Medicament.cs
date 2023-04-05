﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        [Key]
        public int MedicamentId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
}
