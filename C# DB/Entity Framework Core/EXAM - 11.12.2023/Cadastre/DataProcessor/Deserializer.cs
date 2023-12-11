using Cadastre.DataProcessor.ImportDtos;
using Cadastre.Utilities;

using Cadastre.Data;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        private static XmlHelper xmlHelper;


        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            var sb = new StringBuilder();
			var xmlHelper = new XmlHelper();
            var districtsDTOs = xmlHelper.Deserialize<ImportDistrictDTO[]>(xmlDocument, "Districts");

            var validDistricts = new HashSet<District>();
            foreach (var importDTO in districtsDTOs)
            {
	            if (!IsValid(importDTO))
	            {
		            sb.AppendLine(ErrorMessage);
                    continue;
	            }

                var validProperties = new HashSet<Property>();
                foreach (var propertyDTO in importDTO.Properties)
                {
	                if (!IsValid(propertyDTO))
	                {
		                sb.AppendLine(ErrorMessage);
						continue;
	                }

					DateTime date;
					var validDate = DateTime
						.TryParseExact(propertyDTO.DateOfAcquisition, "dd/MM/yyyy", CultureInfo
							.InvariantCulture, DateTimeStyles.None, out date);

					
					var property = new Property()
					{
						PropertyIdentifier = propertyDTO.PropertyIdentifier,
                        Area = propertyDTO.Area,
                        Details = propertyDTO.Details,
                        Address = propertyDTO.Address,
                        DateOfAcquisition = date
                        
					};
					if (validProperties.Any(x => x.PropertyIdentifier == propertyDTO.PropertyIdentifier || x.Address == propertyDTO.Address))
					{
						sb.AppendLine(ErrorMessage);
						continue;
					}
					else
					{
						validProperties.Add(property);
					}
					
				}
	            
                var district = new District()
                {
	                Name = importDTO.Name,
                    PostalCode = importDTO.PostalCode,
					Region = Enum.Parse<Region>(importDTO.Region),
					Properties = validProperties
				};

                if (validDistricts.Any(x => x.Name == importDTO.Name))
                {
	                sb.AppendLine(ErrorMessage);
	                continue;
                }
                else
                {
					validDistricts.Add(district);
					sb.AppendLine(string.Format(String.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count)));
				}
                
            }

            dbContext.Districts.AddRange(validDistricts);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
		}

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
           var sb = new StringBuilder();
           var citizensDTOs = JsonConvert.DeserializeObject < ImportCitizenDTO[]>(jsonDocument);
           var validCitizens = new HashSet<Citizen>();
           var existingProperties = dbContext.Properties.Select(x => x.Id).ToList();

           foreach (var citizenDTO in citizensDTOs)
           {
	           if (!IsValid(citizenDTO))
	           {
		           sb.AppendLine(ErrorMessage);
                   continue;
	           }

	           if (citizenDTO.MaritalStatus != "Unmarried" && citizenDTO.MaritalStatus != "Married" && citizenDTO.MaritalStatus != "Divorced" && citizenDTO.MaritalStatus != "Widowed")
	           {
					sb.AppendLine(ErrorMessage);
					continue;
	           }

	           DateTime date;
	           var validDate = DateTime
		           .TryParseExact(citizenDTO.BirthDate, "dd-MM-yyyy", CultureInfo
			           .InvariantCulture, DateTimeStyles.None, out date);

	           var citizen = new Citizen()
	           {
		           FirstName = citizenDTO.FirstName,
		           LastName = citizenDTO.LastName,
		           BirthDate = date,
		           MaritalStatus = Enum.Parse<MaritalStatus>(citizenDTO.MaritalStatus)
	           };


	           foreach (var propId in citizenDTO.Properties.Distinct())
	           {
		           if (!existingProperties.Contains(propId))
		           {
						sb.AppendLine(ErrorMessage);
						continue;
		           }

				   var property = new PropertyCitizen()
				   {
			           PropertyId = propId,
			           Citizen = citizen
		           };

		           citizen.PropertiesCitizens.Add(property);
	           }

			   validCitizens.Add(citizen);
			   sb.AppendLine(string.Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName, citizen.PropertiesCitizens.Count));

           }

		   dbContext.Citizens.AddRange(validCitizens);
		   dbContext.SaveChanges();

		   return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
