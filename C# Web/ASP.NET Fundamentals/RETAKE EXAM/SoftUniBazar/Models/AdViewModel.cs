using Microsoft.AspNetCore.Identity;
using SoftUniBazar.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Models
{
	public class AdViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

		public decimal Price { get; set; }

		public string OwnerName { get; set; } = null!;


		public string ImageUrl { get; set; } = null!;

		public DateTime CreatedOn { get; set; }

		public string CategoryName { get; set; } = null!;


		
	}
}
