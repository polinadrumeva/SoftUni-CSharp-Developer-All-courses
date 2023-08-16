using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SoftUniBazar.Common.EntityValidations.Ad;

namespace SoftUniBazar.Data.Models
{
	public class Ad
	{
        public Ad()
        {
            this.Buyers = new HashSet<AdBuyer>();
        }

        [Key]
        public int Id { get; set; }

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		public string Description { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }

		[Required]
        public string OwnerId { get; set; } = null!;

		[Required]
		public IdentityUser Owner { get; set; } = null!;

		[Required]
		public string ImageUrl { get; set; } = null!;

		[Required]
		public DateTime CreatedOn { get; set; }

		[Required]
		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }

		[Required]
		public virtual Category Category { get; set; } = null!;

		public virtual ICollection<AdBuyer> Buyers { get; set; }
	}

}
