using Library.Database.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Library.Comon.Constants.BookValidations; 

namespace Library.ViewModels
{
	public class BookViewModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
		public string Author { get; set; } = null!;

		[Required]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		public string Description { get; set; } = null!;

		[Required]
		public string ImageUrl { get; set; } = null!;

		[Required]
		public decimal Rating { get; set; }

		[Range(1, int.MaxValue)]
		public int CategoryId { get; set; }

	}
}
