using Cadastre.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
	[XmlType("Property")]
	public class ImportPropertyDTO
	{
		[XmlElement("PropertyIdentifier")]
		[Required]
		[MinLength(EntityValidations.PropertyIdentifierMinLength)]
		[MaxLength(EntityValidations.PropertyIdentifierMaxLength)]
		public string PropertyIdentifier { get; set; } = null!;

		[XmlElement("Area")]
		[Required]
		[Range(0, int.MaxValue)]
		public int Area { get; set; } 

		[XmlElement("Details")]
		[MinLength(EntityValidations.PropertyDetailsMinLength)]
		[MaxLength(EntityValidations.PropertyDetailsMaxLength)]
		public string? Details { get; set; }

		[XmlElement("Address")]
		[Required]
		[MinLength(EntityValidations.PropertyAddressMinLength)]
		[MaxLength(EntityValidations.PropertyAddressMaxLength)]
		public string Address { get; set; } = null!;

		[XmlElement("DateOfAcquisition")]
		[Required]
		public string DateOfAcquisition { get; set; }
	}
}
