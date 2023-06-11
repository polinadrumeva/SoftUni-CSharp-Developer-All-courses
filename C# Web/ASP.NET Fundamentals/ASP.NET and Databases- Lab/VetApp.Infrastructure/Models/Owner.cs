using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Infrastructure.Models
{
	public class Owner
	{
        public Owner()
        {
            this.Cats = new List<Cat>();
            this.Dogs = new List<Dog>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Cat> Cats { get; set; } 

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}
