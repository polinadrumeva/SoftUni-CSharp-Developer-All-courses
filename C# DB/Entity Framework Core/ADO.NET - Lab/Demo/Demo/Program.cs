using System;
using System.Data.SqlClient;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "";
            var connection = new SqlConnection("");
            connection.Open();
            var query = new SqlCommand("SELECT COUNT(*) FROM Employees");
        }
    }
}
