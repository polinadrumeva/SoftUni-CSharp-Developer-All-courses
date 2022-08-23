using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<System.ComponentModel.Component> components;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer;
            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidComputerType));
            }

            if (this.computers.Contains(computer))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComputerId));
            }

            this.computers.Add(computer);
            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            throw new NotImplementedException();
        }

        public string BuyBest(decimal budget)
        {
            throw new NotImplementedException();
        }

        public string BuyComputer(int id)
        {
            throw new NotImplementedException();
        }

        public string GetComputerData(int id)
        {
            throw new NotImplementedException();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            throw new NotImplementedException();
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            throw new NotImplementedException();
        }
    }
}
