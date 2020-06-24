using System;
using Microsoft.Data.SqlClient;

namespace P06.Remove_Villain
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var connect = new SqlConnection(@"Server = BIBI-PC\SQLEXPRESS; Database = MinionsDB; Integrated Security = true");
            connect.Open();

            var inputIdVillain = int.Parse(Console.ReadLine());
            var findVillainNameQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";

           using  var commandVillainName = new SqlCommand(findVillainNameQuery, connect);
            commandVillainName.Parameters.AddWithValue("@villainId", inputIdVillain);

            var nameVillain = commandVillainName.ExecuteScalar()?.ToString();

            if (nameVillain == null)
            {
                Console.WriteLine("No such villain was found.");
            }
            else
            {
                SqlTransaction taskTrans = connect.BeginTransaction();

                try
                {
                    // Delete Minions from MinionsVillains
                    var deleteMinionQuery = @"DELETE FROM MinionsVillains 
                                          WHERE VillainId = @villainId";

                    using var commandDeleteMinions = new SqlCommand(deleteMinionQuery, connect, taskTrans);
                    commandDeleteMinions.Parameters.AddWithValue("@villainId", inputIdVillain);

                    var countMinions = commandDeleteMinions.ExecuteNonQuery();

                    // Delete Villain
                    var deleteVillainQuery = @"DELETE FROM Villains
                                           WHERE Id = @villainId";

                    using var commandDeleteVillain = new SqlCommand(deleteVillainQuery, connect, taskTrans);
                    commandDeleteVillain.Parameters.AddWithValue("@villainId", inputIdVillain);

                    commandDeleteVillain.ExecuteNonQuery();

                    taskTrans.Commit();

                    Console.WriteLine($"{nameVillain} was deleted.");
                    Console.WriteLine($"{countMinions} minions were released.");
                }
                catch (Exception e)
                {
                    taskTrans.Rollback();
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
