using System.ComponentModel.DataAnnotations;
using static Library.Comon.Constants.CategoryValidations;

namespace Library.ViewModels
{
	public class CategoryViewModel
	{
        public int Id { get; set; }

        [Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;
	}
}
