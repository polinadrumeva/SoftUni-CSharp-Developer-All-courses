using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

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

            string result = GetProductsInRange(db);
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
            var products = mapper.Map<Product[]>(productDto);
           
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
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
                if (!context.Categories.Any(c => c.Id == cp.CategoryId) || 
                    !context.Products.Any(p => p.Id == cp.ProductId))
                {
                    continue;
                }    
                
                
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
    }
}