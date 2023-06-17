using Library.Database.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Library.Comon.Constants.BookValidations;

namespace Library.ViewModels
{
	public class AddBookViewModel
	{
        public AddBookViewModel()
        {
            this.Categories = new HashSet<CategoryViewModel>();
        }

        [Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
		public string Author { get; set; } = null!;

		[Required]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		public string Description { get; set; } = null!;

		[Required(AllowEmptyStrings =false)]
		public string Url { get; set; } = null!;

		[Required]
		[Range(0, 10)]

		public double Rating { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int CategoryId { get; set; }

		[Required]
		[ForeignKey(nameof(CategoryId))]
		public IEnumerable<CategoryViewModel> Categories { get; set; } 

	}
}
