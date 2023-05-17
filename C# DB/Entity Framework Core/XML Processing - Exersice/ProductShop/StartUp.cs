using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new ProductShopContext();
            //var inputXml = File.ReadAllText("../../../Datasets/users.xml");
            //var inputXml = File.ReadAllText("../../../Datasets/products.xml");
            //var inputXml = File.ReadAllText("../../../Datasets/categories.xml");
            //var inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            Console.WriteLine(GetProductsInRange(db));
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Users");

            var serializer = new XmlSerializer(typeof(ImportUserDTO[]), xmlRoot);

            using var reader = new StringReader(inputXml);
            var usersDTO = (ImportUserDTO[])serializer.Deserialize(reader);
            var validUsers = new List<User>();
            foreach (var userDTO in usersDTO)
            {
                if (string.IsNullOrEmpty(userDTO.FirstName) || string.IsNullOrEmpty(userDTO.LastName))
                {
                    continue;
                }

                var user = new User()
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Age = userDTO.Age
                };

                validUsers.Add(user);
            }

            context.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Products");

            var serializer = new XmlSerializer(typeof(ImportProductDTO[]), xmlRoot);

            using var reader = new StringReader(inputXml);
            var productsDTO = (ImportProductDTO[])serializer.Deserialize(reader);
            var validProducts = new List<Product>();
            foreach (var productDTO in productsDTO)
            {
                if (productDTO.BuyerId == null)
                {
                    continue;
                }

                var product = new Product()
                {
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    SellerId = productDTO.SellerId,
                    BuyerId = productDTO.BuyerId
                };

                validProducts.Add(product);
            }

            context.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Categories");

            var serializer = new XmlSerializer(typeof(ImportCategoryDTO[]), xmlRoot);

            using var reader = new StringReader(inputXml);
            var categoriesDTO = (ImportCategoryDTO[])serializer.Deserialize(reader);
            var validCategories = new List<Category>();
            foreach (var categoryDTO in categoriesDTO)
            {
                if (string.IsNullOrEmpty(categoryDTO.Name))
                {
                    continue;
                }

                var category = new Category()
                {
                    Name = categoryDTO.Name
                };

                validCategories.Add(category);
            }

            context.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("CategoryProducts");

            var serializer = new XmlSerializer(typeof(ImportCategoryProductDTO[]), xmlRoot);

            using var reader = new StringReader(inputXml);
            var categoriesProductsDTO = (ImportCategoryProductDTO[])serializer.Deserialize(reader);
            var validCategoriesProducts = new List<CategoryProduct>();
            foreach (var cpDTO in categoriesProductsDTO)
            {
                if (!context.Categories.Any(c => c.Id == cpDTO.CategoryId) || !context.Products.Any(p => p.Id == cpDTO.ProductId))
                {
                    continue;
                }

                var categoryProduct = new CategoryProduct()
                {
                   CategoryId = cpDTO.CategoryId,
                   ProductId = cpDTO.ProductId
                };

                validCategoriesProducts.Add(categoryProduct);
            }

            context.AddRange(validCategoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoriesProducts.Count}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>()));
            var sb = new StringBuilder();

            var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                                  .OrderBy(p => p.Price)
                                  .Take(10)
                                  .Select(p => new ExportProductInRangeDto
                                  {
                                      Name = p.Name,
                                      Price = p.Price,
                                      BuyerFullName = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                                  }).ToArray();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var xmlRoot = new XmlRootAttribute("Products");
            var serializer = new XmlSerializer(typeof(ExportProductInRangeDto[]), xmlRoot);
            using var writer = new StringWriter(sb);
            serializer.Serialize(writer, products, namespaces);

            return sb.ToString().TrimEnd();
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>()));
            var sb = new StringBuilder();

            var users = context.Users.Where(u => u.ProductsSold.Count() >= 1)
                                .OrderBy(u => u.LastName)
                                .ThenBy(u => u.FirstName)
                                .Select(u => new ExportUserDTO 
                                { 
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    Products = new[](new ExportProductDTO()
                                    {
                                    }
                                    ).ToArray()
                                  
                                }).Take(10)
                                .ToArray();

            
            var xmlRoot = new XmlRootAttribute("Products");
            var serializer = new XmlSerializer(typeof(ExportProductInRangeDto[]), xmlRoot);
            using var writer = new StringWriter(sb);
            serializer.Serialize(writer, products, namespaces);

            return sb.ToString().TrimEnd();
        }

        //07. Export Categories By Products Count

        //08. Export Users and Products
    }
}