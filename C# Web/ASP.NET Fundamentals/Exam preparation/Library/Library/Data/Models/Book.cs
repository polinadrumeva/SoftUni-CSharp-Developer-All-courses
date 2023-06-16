using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using static Library.Comon.Constants.BookValidations;



namespace Library.Database.Models
{
	public class Book
	{
        public Book()
        {
            this.UsersBooks = new HashSet<IdentityUserBook>();
        }

        [Required]
		[Key]
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

		[Required]
		public int CategoryId { get; set; }

		[Required]
		[ForeignKey(nameof(CategoryId))]
		public Category Category { get; set; }

		public ICollection<IdentityUserBook> UsersBooks { get; set; }
	}

//	Has Id – a unique integer, Primary Key
//• Has Title – a string with min length 10 and max length 50 (required)
//• Has Author – a string with min length 5 and max length 50 (required)
//• Has Description – a string with min length 5 and max length 5000 (required)
//• Has ImageUrl – a string (required)
//• Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
//• Has CategoryId – an integer, foreign key(required)
//• Has Category – a Category(required)
//• Has UsersBooks – a collection of type IdentityUserBook
}
