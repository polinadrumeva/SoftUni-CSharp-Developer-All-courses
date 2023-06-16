using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Database.Models
{
	public class IdentityUserBook
	{
		public string CollectorId { get; set; } = null!;

		public IdentityUser Collector { get; set; } = null!;

		public int BookId { get; set; }

		public Book Book { get; set; } = null!;
	}

//	CollectorId – a string, Primary Key, foreign key(required)
//• Collector – IdentityUser
//• BookId – an integer, Primary Key, foreign key(required)
//• Book – Book
}
