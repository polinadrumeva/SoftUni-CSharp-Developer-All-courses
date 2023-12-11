using System.ComponentModel.DataAnnotations;
using Cadastre.Common;
using Cadastre.Data.Enumerations;

namespace Cadastre.Data.Models
{
	public class Citizen
	{
		public Citizen()
		{
			this.PropertiesCitizens = new HashSet<PropertyCitizen>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(EntityValidations.NameMinLength)]
		[MaxLength(EntityValidations.NameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MinLength(EntityValidations.NameMinLength)]
		[MaxLength(EntityValidations.NameMaxLength)]
		public string LastName { get; set; } = null!;

		[Required]
		public DateTime BirthDate { get; set; }

		[Required]
		public MaritalStatus MaritalStatus { get; set; }

		public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }

		
	}
}
