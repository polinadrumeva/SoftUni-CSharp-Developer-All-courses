using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
        [Key]
        public int DiagnoseId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(250)]
        public string Comments  { get; set; } = null!;

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; } = null!;
    }
}
