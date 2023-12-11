using Cadastre.Common;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
	[XmlType("District")]
	public class ImportDistrictDTO
	{
		[XmlElement("Name")]
		[Required]
		[MinLength(EntityValidations.DistrictNameMinLength)]
		[MaxLength(EntityValidations.DistrictNameMaxLength)]
		public string Name { get; set; } = null!;

		[XmlElement("PostalCode")]
		[Required]
		[MinLength(EntityValidations.PostalCodeMaxLength)]
		[RegularExpression(EntityValidations.ValidationPostalCode)]
		public string PostalCode { get; set; } = null!;

		[XmlAttribute("Region")]
		[Required]
		public string Region { get; set; } = null!;

		[XmlArray("Properties")]
		public ImportPropertyDTO[] Properties { get; set; } = null!;
	}
}
