using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public string Name { get; set; }
        public decimal Cost { get; set; }

        public Product(string name, decimal price)
        {
            this.Name = name;   
            this.Cost = price;
        }
    }
}
