using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;
using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
			var propertiesWithOwners = dbContext.Properties
				.Include(p => p.PropertiesCitizens)
				.ThenInclude(p => p.Citizen)
				.AsNoTracking()
				.OrderByDescending(p => p.DateOfAcquisition)
				.ThenBy(p => p.PropertyIdentifier)
				.ToArray()
				.Where(p => p.DateOfAcquisition >= new DateTime(2000, 1, 1))
				.Select(p => new
				{
					PropertyIdentifier = p.PropertyIdentifier,
					Area = p.Area,
					Address = p.Address,
					DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"), 
					Owners = p.PropertiesCitizens
						.Select(pc => new
						{
							LastName = pc.Citizen.LastName,
							MaritalStatus = pc.Citizen.MaritalStatus.ToString(),
						})
						.OrderBy(c => c.LastName)
						.ToArray()
				})
				.ToArray();
			

			var json = JsonConvert.SerializeObject(propertiesWithOwners, Formatting.Indented);

			return json;
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {

			var sb = new StringBuilder();

			var serializer = new XmlSerializer(typeof(ExportPropertyDTO[]), new XmlRootAttribute("Properties"));
			var namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty);

			using StringWriter writer = new StringWriter(sb);

			var properties = dbContext.Properties
				.AsNoTracking()
				.Where(p => p.Area >= 100)
				.OrderByDescending(p => p.Area)
				.ThenBy(p => p.DateOfAcquisition)
				.Select(p => new ExportPropertyDTO
				{
					PropertyIdentifier = p.PropertyIdentifier,
					Area = p.Area,
					DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
					PostalCode = p.District.PostalCode
				})
				.ToArray();

			serializer.Serialize(writer, properties, namespaces);

			return sb.ToString().Trim();
		}
    }
}
