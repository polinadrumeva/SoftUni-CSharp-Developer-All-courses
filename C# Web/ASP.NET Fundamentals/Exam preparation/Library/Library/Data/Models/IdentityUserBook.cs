using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Database.Models
{
	public class IdentityUserBook
	{
		public string CollectorId { get; set; } = null!;

		[ForeignKey(nameof(CollectorId))]
		public IdentityUser Collector { get; set; } = null!;

		public int BookId { get; set; }

		[ForeignKey(nameof(BookId))]
		public Book Book { get; set; } = null!;
	}

//	CollectorId – a string, Primary Key, foreign key(required)
//• Collector – IdentityUser
//• BookId – an integer, Primary Key, foreign key(required)
//• Book – Book
}
