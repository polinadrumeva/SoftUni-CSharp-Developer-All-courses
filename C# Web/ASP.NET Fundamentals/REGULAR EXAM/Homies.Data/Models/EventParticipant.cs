using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homies.Data.Models
{
	public class EventParticipant
	{
		[Required]
		public string HelperId { get; set; } = null!;

		public IdentityUser Helper { get; set; } = null!;

		[Required]
		public int EventId { get; set; }

		public Event Event { get; set; } = null!;
	}
}
