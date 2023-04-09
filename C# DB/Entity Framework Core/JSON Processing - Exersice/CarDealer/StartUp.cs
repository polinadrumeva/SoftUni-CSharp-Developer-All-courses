using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new CarDealerContext();

            //var jsonString = File.ReadAllText(@"../../../Datasets/suppliers.json");
            var jsonString = File.ReadAllText(@"../../../Datasets/parts.json");
            var result = ImportParts(db, jsonString);
            Console.WriteLine(result);
        }

        private static IMapper CreateMapper()
        { 
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var mapper = CreateMapper();

            var suppliersDto = JsonConvert.DeserializeObject<SupplierDTO[]>(inputJson);

            var validSupplier = new HashSet<Supplier>();
            foreach (var s in suppliersDto)
            {
                var supp = mapper.Map<Supplier>(s);
                validSupplier.Add(supp);
                
            }

            context.Suppliers.AddRange(validSupplier);
            context.SaveChanges();

            return $"Successfully imported {validSupplier.Count}";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var mapper = CreateMapper();

            var partsDto = JsonConvert.DeserializeObject<PartDto[]>(inputJson);

            var validParts = new HashSet<Part>();
            foreach (var s in partsDto)
            {
                var id = s.SupplierId;
                var existSup = context.Suppliers.Where(sup => sup.Id == id).ToArray();
                if (existSup != null)
                {
                    var part = mapper.Map<Part>(s);
                    validParts.Add(part);
                }
               
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }
    }
}