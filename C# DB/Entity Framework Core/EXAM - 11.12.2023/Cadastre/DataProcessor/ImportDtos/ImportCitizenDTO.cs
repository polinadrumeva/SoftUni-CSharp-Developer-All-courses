

using Cadastre.Common;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor.ImportDtos
{
	public class ImportCitizenDTO
	{

		[JsonProperty("FirstName")]
		[Required]
		[MinLength(EntityValidations.NameMinLength)]
		[MaxLength(EntityValidations.NameMaxLength)]
		public string FirstName { get; set; } = null!;

		[JsonProperty("LastName")]
		[Required]
		[MinLength(EntityValidations.NameMinLength)]
		[MaxLength(EntityValidations.NameMaxLength)]
		public string LastName { get; set; } = null!;

		[JsonProperty("BirthDate")]
		[Required]
		public string BirthDate { get; set; }

		[JsonProperty("MaritalStatus")]
		[Required]
		public string MaritalStatus { get; set; }

		[JsonProperty("Properties")]
		public int[] Properties{ get; set; }
	}
}
