using System;

namespace PT_HospitalApp.Models
{
    public class MedicalRecord
    {
        // Solution: use Guid instead of int
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string DoctorName { get; set; }
    }
}
