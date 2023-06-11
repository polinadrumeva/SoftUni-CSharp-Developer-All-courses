using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Infrastructure.Models
{
	public class Cat
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(20)]
		public string CatName { get; set; } = null!;

		[Required]
		[Range(0, 30)]
		public int Age { get; set; }

		public DateTime? Birthdate { get; set; }
		public int? OwnerId { get; set; }

		public Owner Owner { get; set; }

		[Range(0.00, 50.00)]
		public double Weight { get; set; }

		[Required]
		public bool IsVacsinated { get; set; }
	}
}
