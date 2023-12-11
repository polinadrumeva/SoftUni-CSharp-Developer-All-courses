using System.ComponentModel.DataAnnotations;
using Cadastre.Common;
using Cadastre.Data.Enumerations;

namespace Cadastre.Data.Models
{
	public class District
	{
		public District()
		{
			this.Properties = new HashSet<Property>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(EntityValidations.DistrictNameMinLength)]
		[MaxLength(EntityValidations.DistrictNameMaxLength)]
		public string Name { get; set; }

		[Required]
		[MinLength(EntityValidations.PostalCodeMaxLength)]
		public string PostalCode { get; set; }

		[Required]
		public Region Region { get; set; }

		public virtual ICollection<Property> Properties { get; set; }

		

	}
}
