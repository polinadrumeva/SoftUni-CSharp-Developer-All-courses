using Microsoft.AspNetCore.Identity;
using SoftUniBazar.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static SoftUniBazar.Common.EntityValidations.Ad;

namespace SoftUniBazar.Models
{
	public class AddFormAdViewModel
	{
        public AddFormAdViewModel()
        {
            this.Categories = new HashSet<CategoryViewModel>();
        }

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
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Range(1, int.MaxValue)]
		public int CategoryId { get; set; }

		[Required]
		[ForeignKey(nameof(CategoryId))]
		public IEnumerable<CategoryViewModel> Categories { get; set; }
	}
}
