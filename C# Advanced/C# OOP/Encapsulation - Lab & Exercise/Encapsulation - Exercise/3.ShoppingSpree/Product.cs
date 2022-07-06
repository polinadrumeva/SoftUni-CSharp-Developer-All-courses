using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public decimal Cost
        {
            get
            {
                return this.cost;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    this.cost = value;
                }
            }
        }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Cost = price;
        }
    }
}
