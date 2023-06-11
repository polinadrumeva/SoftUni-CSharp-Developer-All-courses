using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Infrastructure.Models
{
	public class Dog
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string DogName { get; set; } = null!;
        [Required]
        [Range(0,25)]
        public int Age { get; set; }

        public DateTime? Birthdate { get; set; }
        public int? OwnerId { get; set; }

		public Owner Owner { get; set; }

        [Required]
        [Range(0.00, 100.00)]
        public double Weight { get; set; }

        [Required]
        public bool IsVacsinated { get; set; }
    }
}
