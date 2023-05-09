using CarDealer.Data;
using CarDealer.DTOs.Import;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {

        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Suppliers");

            var serializer = new XmlSerializer(typeof(ImportSupplierDTO[]), xmlRoot);

            var reader = new StringReader(inputXml);
            var suppliersDTO = (ImportSupplierDTO[])serializer.Deserialize(reader);

            
        }
    }
}