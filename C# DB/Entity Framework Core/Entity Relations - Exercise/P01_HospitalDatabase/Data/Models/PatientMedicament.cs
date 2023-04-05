using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; } = null!;

        public int MedicamentId { get; set; }

        public virtual Medicament Medicament { get; set; } = null!;
    }
}
