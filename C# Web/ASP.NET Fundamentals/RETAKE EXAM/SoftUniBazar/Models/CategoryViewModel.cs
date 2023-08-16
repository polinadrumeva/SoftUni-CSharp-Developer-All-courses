using System.ComponentModel.DataAnnotations;

using static SoftUniBazar.Common.EntityValidations.Category;

namespace SoftUniBazar.Models
{
	public class CategoryViewModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;
	}
}
