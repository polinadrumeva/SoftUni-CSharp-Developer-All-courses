using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new CarDealerContext();
            //string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string inputXml = File.ReadAllText("../../../Datasets/parts.xml");
            //string inputXml = File.ReadAllText("../../../Datasets/cars.xml");
            //string inputXml = File.ReadAllText("../../../Datasets/customers.xml");
            string inputXml = File.ReadAllText("../../../Datasets/sales.xml");
            Console.WriteLine(ImportSales(db,inputXml));
        }

        //09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Suppliers");

            var serializer = new XmlSerializer(typeof(ImportSupplierDTO[]), xmlRoot);

            using var reader = new StringReader(inputXml);
            var suppliersDTO = (ImportSupplierDTO[])serializer.Deserialize(reader);
            var validSuppliers = new List<Supplier>();
            foreach (var supplierDTO in suppliersDTO)
            {
                if (string.IsNullOrEmpty(supplierDTO.Name))
                {
                    continue;
                }

                var supplier = new Supplier()
                { 
                    Name = supplierDTO.Name,
                    IsImporter = supplierDTO.IsImporter
                };

                validSuppliers.Add(supplier);
            }

            context.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        //10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Parts");

            var serializer = new XmlSerializer(typeof(ImportPartsDTO[]), xmlRoot);

            using var reader = new StringReader(inputXml);
            var partsDTO = (ImportPartsDTO[])serializer.Deserialize(reader);
            var validParts = new List<Part>();
            foreach (var partDTO in partsDTO)
            {
                var supplier = context.Suppliers.FirstOrDefault(s => s.Id == partDTO.SupplierId);
                if (string.IsNullOrEmpty(partDTO.Name) || supplier == null)
                {
                    continue;
                }

                var part = new Part()
                {
                    Name = partDTO.Name,
                    Price = partDTO.Price,
                    Quantity = partDTO.Quantity,
                    SupplierId = partDTO.SupplierId
                };

                validParts.Add(part);
            }

            context.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        //11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Cars");
            var serializer = new XmlSerializer(typeof(ImportCarDTO[]), xmlRoot);
            using var reader = new StringReader(inputXml);
            var carsDTO = (ImportCarDTO[])serializer.Deserialize(reader);
            var validCars = new List<Car>();

            foreach (var carDTO in carsDTO)
            {
                if (string.IsNullOrEmpty(carDTO.Make) || string.IsNullOrEmpty(carDTO.Model))
                {
                    continue;
                }

                var car = new Car()
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TraveledDistance = carDTO.TraveledDistance
                };   

                foreach (var partDTO in carDTO.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == partDTO.PartId))
                    {
                        continue;
                    }

                    var carPart = new PartCar()
                    {
                        PartId = partDTO.PartId
                    };

                    car.PartsCars.Add(carPart);
                }

                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        //12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Customers");

            var serializer = new XmlSerializer(typeof(ImportCustomerDTO[]), xmlRoot);
            var reader = new StringReader(inputXml);
            var customersDTO = (ImportCustomerDTO[])serializer.Deserialize(reader);
            var validCustomers = new List<Customer>();

            foreach (var customerDTO in customersDTO)
            {
                if (string.IsNullOrEmpty(customerDTO.Name) || string.IsNullOrEmpty(customerDTO.BirthDate))
                {
                    continue;
                }

                var customer = new Customer()
                {
                    Name = customerDTO.Name,
                    BirthDate = DateTime.Parse(customerDTO.BirthDate, CultureInfo.InvariantCulture),
                    IsYoungDriver = customerDTO.IsYoungDriver
                };

                validCustomers.Add(customer);
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";
        }

        //13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Sales");

            var serializer = new XmlSerializer(typeof(ImportSaleDTO[]), xmlRoot);
            var reader = new StringReader(inputXml);
            var salesDTO = (ImportSaleDTO[])serializer.Deserialize(reader);
            var validSales = new List<Sale>();

            foreach (var saleDTO in salesDTO)
            {
                if (!context.Cars.Any(c => c.Id == saleDTO.CarId))
                {
                    continue;
                }

                var sale = new Sale()
                {
                    Discount = saleDTO.Discount,
                    CarId = saleDTO.CarId,
                    CustomerId = saleDTO.CustomerId
                };

                validSales.Add(sale);
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }
    }
}