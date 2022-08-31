using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Peripherals
{
    public abstract class Peripheral : IPeripheral
    {
        public string ConnectionType { get; private set; }

        public int Id { get; private set; }

        public string Manufacturer { get; private set; }

        public string Model { get; private set; }

        public decimal Price { get; private set; }

        public double OverallPerformance { get; private set; }

        public Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
            this.ConnectionType = connectionType;
        }

        public override string ToString()
        {
            return $"Overall Performance: {this.OverallPerformance}. Price: {this.Price} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id}) Connection Type: {this.ConnectionType}";
        }
    }
}
