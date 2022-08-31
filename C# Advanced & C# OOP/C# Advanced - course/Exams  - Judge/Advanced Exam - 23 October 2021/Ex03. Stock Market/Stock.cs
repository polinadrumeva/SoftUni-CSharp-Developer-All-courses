using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization { get; set; }

        public Stock(string name, string director, decimal pricePerShare, int totalNumbersOfShare)
        {
            this.CompanyName = name;
            this.Director = director;   
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumbersOfShare;
            this.MarketCapitalization = this.PricePerShare * this.TotalNumberOfShares;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Company: {CompanyName}");
            sb.AppendLine($"Director: {Director}");
            sb.AppendLine($"Price per share: ${PricePerShare}");
            sb.Append($"Market capitalization: ${MarketCapitalization}");

            return sb.ToString();
        }
    }
}
