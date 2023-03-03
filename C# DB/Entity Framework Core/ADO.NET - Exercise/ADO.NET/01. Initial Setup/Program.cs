using Microsoft.Data.SqlClient;
using System;

namespace _01._Initial_Setup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB;TrustServerCertificate=true";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount " +
                                    "FROM Villains AS v " +
                                    "JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                                    "GROUP BY v.Id, v.Name HAVING COUNT(mv.VillainId) > 3 " +
                                    "ORDER BY COUNT(mv.VillainId)";

                var sqlCommand = new SqlCommand(query, connection);
                var result = sqlCommand.ExecuteReader();

                while (result.Read())
                {
                    string villainName = (string)result["Name"];
                    int count = (int)result["MinionsCount"];

                    Console.WriteLine($"{villainName} - {count}");

                }
            }
        }
    }
}
