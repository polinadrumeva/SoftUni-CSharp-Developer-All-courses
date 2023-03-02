using System;
using System.Data.SqlClient;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // without using
            //string connectionString = "Server=.;Integrated Security=true;Database=SoftUni";
            //var connection = new SqlConnection(connectionString);
            //connection.Open();

            //with using
            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection.Open();

                //string query = "SELECT COUNT(*) FROM Employees";
                //SqlCommand sqlCommand = new SqlCommand(query, connection);

                string queryUpdate = "UPDATE Employees SET Salary = Salary + 0.12";
                SqlCommand cmd = new SqlCommand(queryUpdate, connection);
                var rowsaffected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsaffected);

            }

            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection.Open();

                string queryUpdate = "SELECT COUNT(*) FROM Employees";
                SqlCommand cmd = new SqlCommand(queryUpdate, connection);
                var result = (int)cmd.ExecuteScalar();
                Console.WriteLine(result);

            }

            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=SoftUni"))
            {
                connection.Open();

                string queryUpdate = "SELECT * FROM Employees";
                var cmd = new SqlCommand(queryUpdate, connection);
                SqlDataReader result = cmd.ExecuteReader();
                result.Read();
                Console.WriteLine(result[1]);
                result.Read();
                Console.WriteLine(result[1]);
                result.Read();
                Console.WriteLine(result[1]);

            }
        }
    }
}
