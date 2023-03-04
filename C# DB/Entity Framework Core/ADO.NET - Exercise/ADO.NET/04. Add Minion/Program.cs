using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _04._Add_Minion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB;TrustServerCertificate=true";

            string minionInfo = Console.ReadLine();
            string[] minionArgs = minionInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string minionName = minionArgs[1];
            int minionAge = int.Parse(minionArgs[2]);
            string minionTown = minionArgs[3];

            string villainInfo = Console.ReadLine();
            string[] villainArgs = villainInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string villainName = villainArgs[1];

            var sb = new StringBuilder();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //SqlTransaction transaction = connection.BeginTransaction();
                string getTownByIdQuery = @"SELECT Id FROM Towns WHERE Name = @townName";
                string getVillainQuery = @"SELECT Id FROM Villains WHERE Name = @Name";

                try
                {
                    //Check for Town and added if not exist
                    var getTownById = new SqlCommand(getTownByIdQuery, connection);
                    getTownById.Parameters.AddWithValue("@townName", minionTown);
                    object? townId = getTownById.ExecuteScalar();
                    if (townId == null)
                    {
                        string addTownQuery = @"INSERT INTO Towns (Name) VALUES (@townName)";
                        var addTown = new SqlCommand(addTownQuery, connection);
                        addTown.Parameters.AddWithValue("@townName", minionTown);
                        addTown.ExecuteNonQuery();
                        int tId = (int)addTown.ExecuteScalar();
                        sb.AppendLine($"Town {minionTown} was added to the database.");
                    }

                    //Check for villain and added if not exist
                    var getVillainByName = new SqlCommand(getVillainQuery, connection);
                    getTownById.Parameters.AddWithValue("@@Name", villainName);
                    object? villainId = getTownById.ExecuteScalar();

                    if (villainId == null)
                    {
                        string addVillainQuery = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4))";
                        var addVillaind = new SqlCommand(addVillainQuery, connection);
                        addVillaind.Parameters.AddWithValue("@@villainName", villainName);
                        addVillaind.ExecuteNonQuery();
                        villainId = (int)addVillaind.ExecuteScalar();
                        sb.AppendLine($"Villain {villainName} was added to the database.");
                    }
                   

                    //Added minion
                    string addedMinionQuery = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
                    var addedMinion = new SqlCommand(addedMinionQuery, connection);
                    addedMinion.Parameters.AddWithValue("@name", minionName);
                    addedMinion.Parameters.AddWithValue("@age", minionAge);
                    addedMinion.Parameters.AddWithValue("@townId", minionTown);
                    addedMinion.ExecuteNonQuery();
                    int mId = (int)addedMinion.ExecuteScalar();

                    //Added minion to villain
                    string addMinionToVillainQuery = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
                    var addMinion = new SqlCommand(addMinionToVillainQuery, connection);
                    addedMinion.Parameters.AddWithValue("@minionId", mId);
                    addedMinion.Parameters.AddWithValue("@villainId", villainId);
                    addedMinion.ExecuteNonQuery();
                    sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                    //transaction.Commit();
                }
                catch (Exception)
                {
                    //transaction.Rollback();
                }

                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }  
        
    }
}
