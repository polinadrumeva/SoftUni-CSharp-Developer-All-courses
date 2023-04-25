namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product()
        {
            this.CategoriesProducts = new HashSet<CategoryProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int SellerId { get; set; }
        public User Seller { get; set; } = null!;

        public int? BuyerId { get; set; }
        public User? Buyer { get; set; }

        public ICollection<CategoryProduct> CategoriesProducts { get; set; }
    }
}