using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public List<Stock> Portfolio { get; set; }
        public int Count { get { return Portfolio.Count; } }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public Investor(string fullName, string emailAdress, decimal moneyToInvest, string brokerName)
        {
            this.Portfolio = new List<Stock>();
            this.FullName = fullName;
            this.EmailAddress = emailAdress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && stock.PricePerShare < MoneyToInvest)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (Portfolio.FirstOrDefault(x => x.CompanyName == companyName) == null)
            {
                return $"{companyName} does not exist.";
            }

            Stock toRemove = Portfolio.First(x => x.CompanyName == companyName);
            if (sellPrice < toRemove.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                MoneyToInvest -= toRemove.PricePerShare;
                Portfolio.Remove(toRemove);
                return $"{companyName} was sold.";
            }
        }

        public Stock FindStock(string companyName)
        {
            Stock stock = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (stock == null)
            {
                return null;
            }
            else
            {
                return stock;
            }
        }

        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count == 0)
            {
                return null;
            }
            else
            {
                Portfolio.Max(x => x.MarketCapitalization);
                return Portfolio.First();
            }
        }

        public string InvestorInformation()
        { 
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks: ");
            foreach (var stock in Portfolio)
            {
                stringBuilder.AppendLine(stock.ToString());
            }

            return stringBuilder.ToString();    
        }
    }
}
