using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Homies.Common.Validations.ValidationConstants.TypeValidations;

namespace Homies.Data.Models
{
	public class Type
	{
		public Type()
		{
			this.Events = new HashSet<Event>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(MaxTypeNameLength, MinimumLength = MinTypeNameLength)]
		public string Name { get; set; } = null!;

		public virtual ICollection<Event> Events { get; set; }
	}

//	Has Id – a unique integer, Primary Key
// Has Name – a string with min length 5 and max length 15 (required)
// Has Events – a collection of type Event
}
