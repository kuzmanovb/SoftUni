using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P03.Minion_Names
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var connect = new SqlConnection(@"Server = BIBI-PC\SQLEXPRESS; Database = MinionsDB; Integrated Security = true");
            connect.Open();

            var villainId = int.Parse(Console.ReadLine());

            var queryFindExistsId = @"SELECT Name FROM Villains WHERE Id = @Id";
            using var command = new SqlCommand(queryFindExistsId, connect);
            command.Parameters.AddWithValue("@Id", villainId);

            var nameVillian = command.ExecuteScalar()?.ToString();

            if (nameVillian != null)
            {
                var sb = new StringBuilder();

                sb.AppendLine($"Villain: {nameVillian}");

                var query2 = @"SELECT 
                                    ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                    m.Name, 
                                    m.Age
                               FROM MinionsVillains AS mv
                               JOIN Minions As m ON mv.MinionId = m.Id
                               WHERE mv.VillainId = @Id
                               ORDER BY m.Name";

                using var command2 = new SqlCommand(query2, connect);
                command2.Parameters.AddWithValue("@Id", villainId);
                var reader = command2.ExecuteReader();

                if (!reader.HasRows)
                {
                    sb.AppendLine("(no minions)");
                }
                else
                {

                    while (reader.Read())
                    {
                        sb.AppendLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                    }
                }

                Console.WriteLine(sb.ToString().TrimEnd());
            }
            else
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
        }
    }
}
