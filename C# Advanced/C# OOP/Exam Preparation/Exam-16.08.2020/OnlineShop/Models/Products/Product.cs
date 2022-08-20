using OnlineShop.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private int id;
        private string manufacurer;
        private string model;
        private decimal price;
        private double overallPerformance;
        public int Id
        {
            get
            { 
                return this.id;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidProductId));
                }

                this.id = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacurer;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidManufacturer));
                }

                this.manufacurer = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel));
                }

                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPrice));
                }

                this.price = value;
            }
        }

        public double OverallPerformance
        {
            get
            {
                return this.overallPerformance;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidOverallPerformance));
                }

                this.overallPerformance = value;
            }
        }

        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;   
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public override string ToString()
        {
            return $"Overall Performance: {this.OverallPerformance}. Price: {this.Price} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})";
        }
    }
}
