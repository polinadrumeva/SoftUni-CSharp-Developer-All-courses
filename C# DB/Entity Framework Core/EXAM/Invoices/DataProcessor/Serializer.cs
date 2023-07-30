namespace Invoices.DataProcessor
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InvoicesProfile>();
            });

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ExportClientDto[]), new XmlRootAttribute("Clients"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            var clientDtos = context
                .Clients
                .Where(c => c.Invoices.Any() && c.ProductsClients.Any(ps => ps.Client.Invoices.Any( s => s.IssueDate > date)))
                .ProjectTo<ExportClientDto>(config)
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(c => c.Name)
                .ToArray();

            xmlSerializer.Serialize(sw, clientDtos, namespaces);
            return sb.ToString().TrimEnd();
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {

            var products = context
               .Products
               .Where(p => p.ProductsClients.Count > 1 && p.ProductsClients.Any(c => c.Client.Name.Length == nameLength))
               .ToArray()
               .Select(s => new
               {
                   s.Name,
                   s.Price,
                   Category = s.CategoryType.ToString(),
                   Clients = s.ProductsClients
                       .Where(p => p.Client.Name.Length == nameLength)
                       .ToArray()
                       .OrderBy(bs => bs.Client.Name)
                       .Select(bs => new
                       {
                           Name = bs.Client.Name,
                           NumberVat = bs.Client.NumberVat
                       })
                       .ToArray()
               })
               .OrderByDescending(s => s.Clients.Count())
               .ThenBy(s => s.Name)
               .Take(5)
               .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}