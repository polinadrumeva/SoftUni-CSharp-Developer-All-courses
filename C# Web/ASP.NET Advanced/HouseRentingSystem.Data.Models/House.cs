using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

using static HouseRantingSystem.Common.EntityValidation.House;

namespace HouseRentingSystem.Data.Models
{
	public class House
	{
        public House()
        {
			this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

		[Required]
		[MaxLength(TitleMaxLength)]

		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
        public string ImageUrl { get; set; } = null!;

		[Required]
		public decimal PricePerMonth { get; set; }

		[Required]
        public int CategoryId { get; set; }

		public virtual Category Category { get; set; } = null!;

		[Required]
		public Guid AgentId { get; set; } 

		public virtual Agent Agent { get; set; } = null!;

        public Guid? RenterId { get; set; }

        public ApplicationUser? Renter { get; set; }
    }
}
