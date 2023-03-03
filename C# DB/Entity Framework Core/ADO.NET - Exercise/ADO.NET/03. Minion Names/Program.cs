using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _03._Minion_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB;TrustServerCertificate=true";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int searchedId = int.Parse(Console.ReadLine());

                string firstQuery = @"SELECT Name FROM Villains WHERE Id = @Id";
                
                string secondQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                var checkForInfoConnection = new SqlCommand(firstQuery, connection);
                checkForInfoConnection.Parameters.AddWithValue("@Id", searchedId);
                object? resultForId = checkForInfoConnection.ExecuteScalar();
                if (resultForId == null)
                {
                    Console.WriteLine($"No villain with ID {searchedId} exists in the database.");
                    return;
                }

                string villainName = (string)resultForId;
                var sb = new StringBuilder();

                var takeAllMinions = new SqlCommand(secondQuery, connection);
                takeAllMinions.Parameters.AddWithValue("@Id", searchedId);
                var data = takeAllMinions.ExecuteReader();

                sb.AppendLine($"Villain: {villainName}");
                if (!data.HasRows)
                {
                    sb.AppendLine("(no minions)");
                }
                else
                {
                    while (data.Read())
                    {
                        var rowNumber = (long)data["RowNum"];
                        string name = (string)data["Name"];
                        int age = (int)data["Age"];

                        sb.AppendLine($"{rowNumber}. {name} {age}");
                    }
                }

                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}
