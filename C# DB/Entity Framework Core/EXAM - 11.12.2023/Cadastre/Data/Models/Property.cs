using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cadastre.Common;

namespace Cadastre.Data.Models
{
	public class Property
	{
		public Property()
		{
			this.PropertiesCitizens = new HashSet<PropertyCitizen>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(EntityValidations.PropertyIdentifierMinLength)]
		[MaxLength(EntityValidations.PropertyIdentifierMaxLength)]
		public string PropertyIdentifier { get; set; } = null!;

		[Required]
		public int Area { get; set; }

		[MinLength(EntityValidations.PropertyDetailsMinLength)]
		[MaxLength(EntityValidations.PropertyDetailsMaxLength)]
		public string? Details { get; set; }

		[Required]
		[MinLength(EntityValidations.PropertyAddressMinLength)]
		[MaxLength(EntityValidations.PropertyAddressMaxLength)]
		public string Address { get; set; } = null!;

		[Required]
		public DateTime DateOfAcquisition { get; set; }

		[Required]
		public int DistrictId { get; set; }

		[ForeignKey(nameof(DistrictId))]
		public virtual District District { get; set; } = null!;

		public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }

		

	}
}
