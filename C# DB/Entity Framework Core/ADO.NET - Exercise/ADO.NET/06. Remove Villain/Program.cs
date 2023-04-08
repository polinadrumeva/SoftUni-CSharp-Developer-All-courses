using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _06._Remove_Villain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB;TrustServerCertificate=true";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int vId = int.Parse(Console.ReadLine());

                string searchedVillainsQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";


                var searchedVillain = new SqlCommand(searchedVillainsQuery, connection);
                searchedVillain.Parameters.AddWithValue("@villainId", vId);
                var findVillain = (string)searchedVillain.ExecuteScalar();
                
                var sb = new StringBuilder();

                if (findVillain != null)
                {
                    sb.AppendLine($"{findVillain} was deleted.");
                    string deleteMinionsQuery = @"DELETE FROM MinionsVillains 
                                                    WHERE VillainId = @villainId";
                    var deleteMinion = new SqlCommand(deleteMinionsQuery, connection);
                    deleteMinion.Parameters.AddWithValue("@villainId", vId);
                    var countOfMinions = deleteMinion.ExecuteNonQuery();
                    sb.AppendLine($"{countOfMinions} minions were released.");

                    string deleteVillainQuery = @"DELETE FROM Villains
                                                    WHERE Id = @villainId";
                    var deteleVillain = new SqlCommand(deleteVillainQuery, connection);
                    deteleVillain.Parameters.AddWithValue("@villainId", vId);
                    deteleVillain.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("No such villain was found.");
                }


                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}
