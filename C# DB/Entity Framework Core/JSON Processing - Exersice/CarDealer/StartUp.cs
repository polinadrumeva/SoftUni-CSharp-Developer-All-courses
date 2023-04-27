using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new CarDealerContext();

            //var jsonString = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //var jsonString = File.ReadAllText(@"../../../Datasets/parts.json");
            var jsonString = File.ReadAllText(@"../../../Datasets/cars.json");
            //var jsonString = File.ReadAllText(@"../../../Datasets/customers.json");
            //var jsonString = File.ReadAllText(@"../../../Datasets/sales.json");
            var result = ImportCars(db, jsonString);
            Console.WriteLine(result);
        }


        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

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
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var partsDto = JsonConvert.DeserializeObject<PartDto[]>(inputJson);

            var validParts = new HashSet<Part>();
            foreach (var part in partsDto)
            {
                var id = part.SupplierId;
                var existSup = context.Suppliers.Any(s => s.Id == id);
                if (existSup)
                {
                    var exPart = mapper.Map<Part>(part);
                    validParts.Add(exPart);
                }

            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var carsDto = JsonConvert.DeserializeObject<CarsDTO[]>(inputJson);

            var validCars = new HashSet<Car>();
            var validParts = new HashSet<PartCar>();

            foreach (var car in carsDto)
            {
                var carVal = mapper.Map<Car>(car);
                validCars.Add(carVal);

                foreach (var partId in car.PartsId.Distinct())
                {
                    var partCar = new PartCar()
                    {
                        Car = carVal,
                        PartId = partId,
                    };

                    validParts.Add(partCar);
                }
            }

            context.Cars.AddRange(validCars);
            context.PartsCars.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}.";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var customersDto = JsonConvert.DeserializeObject<CustomerDTO[]>(inputJson);

            var customers = new HashSet<Customer>();

            foreach (var customer in customersDto)
            {
                var newCustomer = mapper.Map<Customer>(customer);
                customers.Add(newCustomer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var salesDto = JsonConvert.DeserializeObject<SaleDTO[]>(inputJson);
            var sales = mapper.Map<Sale[]>(salesDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }
    }
}