using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;
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
            var inputXml = File.ReadAllText("../../../Datasets/categories.xml");

            Console.WriteLine(ImportCategories(db, inputXml));
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
                if (string.IsNullOrEmpty(productDTO.Name) || productDTO.BuyerId == null)
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
    }
}