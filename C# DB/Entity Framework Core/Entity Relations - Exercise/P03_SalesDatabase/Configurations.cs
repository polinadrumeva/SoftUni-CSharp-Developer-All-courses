using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase
{
    public class Configurations
    {
        public static string ConfigurationAddress = "Server=.\\SQLEXPRESS;Database=SalesDatabase;Integrated security=true";

        public const int maxLengthName = 50;

        public const int maxLengthNameCustomer = 100;

        public const int maxLengthEmail = 80;
    }
}
