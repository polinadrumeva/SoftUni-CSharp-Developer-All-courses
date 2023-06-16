using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Library.Comon.Constants.CategoryValidations;

namespace Library.Database.Models
{
	public class Category
	{
		public Category()
		{
			this.Books = new HashSet<Book>();
		}

		[Required]
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;

		public ICollection<Book> Books { get; set; }
	}

//	Has Id – a unique integer, Primary Key
//• Has Name – a string with min length 5 and max length 50 (required)
//• Has Books – a collection of type Books
}
