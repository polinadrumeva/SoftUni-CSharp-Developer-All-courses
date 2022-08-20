using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : IComputer
    {
        private IList<IComponent> components;
        private IList<IPeripheral> peripherals;
        private double overallPerformance;
        private decimal price;
        public IReadOnlyCollection<IComponent> Components => (List<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (List<IPeripheral>) this.peripherals;

        public int Id { get; private set; }

        public string Manufacturer { get; private set; }

        public string Model { get; private set; }

        public decimal Price
        {
            get
            {
                
                    decimal total = this.price + this.components.Sum(c => c.Price) + this.peripherals.Sum(p=> p.Price);
                    return total;
                
            }
            private set
            {
                this.price = value;
            }
        }


        public double OverallPerformance
        {
            get
            {
                if (this.components.Count == 0)
                {
                    return this.overallPerformance;
                }
                else
                {
                    double total = this.overallPerformance + this.components.Average(c => c.OverallPerformance);
                    return total;
                }
            }
            private set
            {
                this.overallPerformance = value;
            }
        }

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override string ToString()
        {
           StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Overall Performance: {this.OverallPerformance}. Price: {this.Price} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            stringBuilder.AppendLine($" Components ({this.components.Count}):");
            foreach (var component in this.Components)
            {
                stringBuilder.AppendLine(component.ToString());
            }

            stringBuilder.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(p => p.OverallPerformance)}):");
            foreach (var peripherals in this.peripherals)
            {
                stringBuilder.AppendLine(peripherals.ToString());
            }
            
            return stringBuilder.ToString().TrimEnd();
        }
        public void AddComponent(IComponent component)
        {
            if (this.components.FirstOrDefault(c=>c.GetType().Name == component.GetType().Name) != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component); 
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.FirstOrDefault(p => p.GetType().Name == peripheral.GetType().Name) != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0 || this.components.FirstOrDefault(c => c.GetType().Name == componentType) == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            IComponent component = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.peripherals.Count == 0 || this.peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType) == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral peripheral = this.peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheral);
            return peripheral;
        }
    }

}
