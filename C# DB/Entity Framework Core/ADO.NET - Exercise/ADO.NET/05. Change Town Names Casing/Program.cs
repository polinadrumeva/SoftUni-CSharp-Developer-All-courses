using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Change_Town_Names_Casing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB;TrustServerCertificate=true";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string searchedCountry = Console.ReadLine();

                string updateQuery = @"UPDATE Towns
                                        SET Name = UPPER(Name)
                                        WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                
                var updateData = new SqlCommand(updateQuery, connection);
                updateData.Parameters.AddWithValue("@countryName", searchedCountry);
                int affectedRow = updateData.ExecuteNonQuery();
                var sb = new StringBuilder();
                var listTowns = new List<string>();

                if (affectedRow > 0)
                {
                    string changedTowns = @"SELECT t.Name 
                                                FROM Towns as t
                                                JOIN Countries AS c ON c.Id = t.CountryCode
                                                WHERE c.Name = @countryName";

                    var chagedData = new SqlCommand(changedTowns, connection);
                    chagedData.Parameters.AddWithValue("@countryName", searchedCountry);
                    var result = chagedData.ExecuteReader();
                    while (result.Read())
                    {
                        listTowns.Add((string)result["Name"]);
                    }

                    sb.AppendLine($"{affectedRow} town names were affected.");
                    sb.AppendLine($"[{string.Join(", ",listTowns)}]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
                

                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}
