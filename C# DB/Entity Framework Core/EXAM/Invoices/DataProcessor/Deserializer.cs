namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(ImportClientDto[]), new XmlRootAttribute("Clients"));

            using StringReader stringReader = new StringReader(xmlString);

            var clientsDtos = (ImportClientDto[])xmlSerializer.Deserialize(stringReader);

            var clients = new List<Client>();

            foreach (var clientDto in clientsDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                string vatNumber = clientDto.NumberVat;
                bool isVatInvalid = string.IsNullOrEmpty(vatNumber);

                if (isVatInvalid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var c = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = vatNumber
                };

                foreach (var address in clientDto.Addresses)
                {
                    if (!IsValid(address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var a = new Address()
                    {
                        StreetName = address.StreetName,
                        StreetNumber = address.StreetNumber,
                        PostCode = address.PostCode,
                        City = address.City,
                        Country = address.Country
                    };

                    c.Addresses.Add(a);
                }
                clients.Add(c);
                sb.AppendLine(String.Format(SuccessfullyImportedClients, c.Name));
            }
            context.Clients.AddRange(clients);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var invoicesDto = JsonConvert.DeserializeObject<ImportInvoiceDto[]>(jsonString);

            var invoices = new List<Invoice>();

            foreach (var invoiceDto in invoicesDto)
            {
                if (!IsValid(invoiceDto) || invoiceDto.DueDate < invoiceDto.IssueDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
;

                var i = new Invoice()
                {
                    Number = invoiceDto.Number,
                    IssueDate = invoiceDto.IssueDate,
                    DueDate = invoiceDto.DueDate,
                    Amount = invoiceDto.Amount,
                    CurrencyType = (CurrencyType)invoiceDto.CurrencyType, 
                    ClientId = invoiceDto.ClientId
                };

                invoices.Add(i);
                sb.AppendLine(String.Format(SuccessfullyImportedInvoices, i.Number));
            }
            context.Invoices.AddRange(invoices);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(jsonString);

            var products = new List<Product>();

            foreach (var prDto in productDtos)
            {
                if (!IsValid(prDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var product = new Product()
                {
                    Name = prDto.Name,
                    Price = prDto.Price,
                    CategoryType = (CategoryType)prDto.CategoryType
                };

                foreach (int clId in prDto.Clients.Distinct())
                {
                    var client = context.Clients.Find(clId);
                    if (client == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    product.ProductsClients.Add(new ProductClient()
                    {
                        Client = client
                    });
                }
                products.Add(product);
                sb.AppendLine(String.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count));
            }
            context.Products.AddRange(products);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
