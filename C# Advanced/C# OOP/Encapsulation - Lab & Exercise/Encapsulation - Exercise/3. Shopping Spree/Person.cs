using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    this.money = value;
                }
            }
        }

        public List<Product> BagOfProducts { get; set; }

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public void BuyProduct(Product product)
        {
            if (this.Money - product.Cost >= 0 )
            {
                this.Money -= product.Cost;
                this.BagOfProducts.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }
    }
}
