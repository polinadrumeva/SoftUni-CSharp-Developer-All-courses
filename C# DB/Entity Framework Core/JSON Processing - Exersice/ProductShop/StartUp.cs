using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new ProductShopContext();

            //string inputJson = File.ReadAllText(@"../../../Datasets/users.json");

            //string inputJson = File.ReadAllText(@"../../../Datasets/products.json");

            //string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");

            //string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");

            //string result = ImportCategoryProducts(db, inputJson);
            //Console.WriteLine(result);

            var result = GetUsersWithProducts(db);
            Console.WriteLine(result);

        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var userDtos = JsonConvert.DeserializeObject<UserDTO[]>(inputJson);

            var validUsers = new HashSet<User>();
            foreach (var user in userDtos)
            { 
                var newUser = mapper.Map<User>(user);

                validUsers.Add(newUser);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var productDto = JsonConvert.DeserializeObject<ProductDTO[]>(inputJson);
            var products = new HashSet<Product>();

            foreach (var product in productDto)
            {
                var newProduct = mapper.Map<Product>(product);

                products.Add(newProduct);
            }
           
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {

            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var categoriesDto = JsonConvert.DeserializeObject<CategoriesDTO[]>(inputJson);

            var validCategories = new HashSet<Category>();
            
            foreach (var c in categoriesDto)
            {
                if (c.Name != null)
                {
                    var categ = mapper.Map<Category>(c);

                    validCategories.Add(categ);
                }
               
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)   
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var categoriesDto = JsonConvert.DeserializeObject<CategoryProductDTO[]>(inputJson);

            var validCategories = new HashSet<CategoryProduct>();
            
            foreach (var cp in categoriesDto)
            {
                //if (!context.Categories.Any(c => c.Id == cp.CategoryId) || 
                //    !context.Products.Any(p => p.Id == cp.ProductId))
                //{
                //    continue;
                //}    
                
                
                var categ = mapper.Map<CategoryProduct>(cp);
                
                validCategories.Add(categ);
                
            }

            context.CategoriesProducts.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        { 
            var products = context.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                                 .OrderBy(p => p.Price)
                                 .Select(p => new   
                                        {
                                            name = p.Name,
                                            price = p.Price,
                                            seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                                        })
                                 .AsNoTracking()
                                 .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            /*Get all users who have at least 1 sold item with a buyer. Order them by the last name, then by the first name. Select the person's first and last name. For each of the sold products (products with buyers), select the product's name, price and the buyer's first and last name.*/

            var users = context.Users.Where(u => u.ProductsSold.Any(x => x.Buyer != null))
                                .OrderBy(u => u.LastName)
                                .ThenBy(u => u.FirstName)
                                .Select(u => new
                                {
                                    firstName = u.FirstName,
                                    lastName = u.LastName,
                                    soldProducts = u.ProductsSold.Where(x => x.Buyer != null).Select(x => new
                                    {
                                        name = x.Name,
                                        price = x.Price,
                                        buyerFirstName = x.Buyer.FirstName,
                                        buyerLastName = x.Buyer.LastName
                                    })
                                }).AsNoTracking()
                                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
                                
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            /*Get all categories. Order them in descending order by the category's products count. For each category select its name, the number of products, the average price of those products (rounded to the second digit after the decimal separator) and the total revenue (total price sum and rounded to the second digit after the decimal separator) of those products (regardless if they have a buyer or not).*/

            var categories = context.Categories.OrderByDescending(x => x.CategoriesProducts.Count())
                                    .Select(x => new
                                        {
                                        category = x.Name,
                                        productsCount = x.CategoriesProducts.Count(),
                                        averagePrice = Math.Round((double)(x.CategoriesProducts.Average(cp => cp.Product.Price)),2),
                                        totalRevenue = Math.Round((double)(x.CategoriesProducts.Sum(cp => cp.Product.Price)), 2)
                                    })
                                    .AsNoTracking()
                                    .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            /*Get all users who have at least 1 sold product with a buyer. Order them in descending order by the number of sold products to a buyer. Select only their first and last name and age and for each product – name and price. Ignore all null values.*/

            var users = context.Users.Where(u => u.ProductsSold.Any(b => b.Buyer != null))
                                .OrderByDescending(u => u.ProductsSold.Count())
                                .Select(u => new 
                                    {
                                       firstName = u.FirstName,
                                       lastName = u.LastName,
                                       age = u.Age,
                                       soldProducts = new
                                       {
                                           count = u.ProductsSold.Count(ps => ps.Buyer != null),
                                           products = u.ProductsSold.Where(ps => ps.Buyer != null).Select(ps => new
                                           {
                                               name = ps.Name,
                                               price = ps.Price
                                           }).ToArray()
                                       }
                                    }).AsNoTracking() 
                                    .ToArray();

            var user = new
            {
                usersCount = users.Length,
                users 
            };

            return JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore});  
        }
    }
}