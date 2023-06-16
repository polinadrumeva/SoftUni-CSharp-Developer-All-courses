using Library.Database.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Library.Comon.Constants.BookValidations;


namespace Library.ViewModels
{
	public class AllBookViewModel
	{
        public int Id { get; set; }
        public string Title { get; set; } = null!;

		public string Author { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public decimal Rating { get; set; }

		public string Category { get; set; } = null!;

	}
}
