using System;
using Microsoft.Data.SqlClient;

namespace P09.Increase_Age_Stored_Procedure
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var connect = new SqlConnection(@"Server = BIBI-PC\SQLEXPRESS; Database = MinionsDB; Integrated Security = true");
            connect.Open();

            var inputId = int.Parse(Console.ReadLine());

            // Use stored procedure
            using var command = new SqlCommand("usp_GetOlder", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", inputId);
            command.ExecuteNonQuery();

            // Print Minions
            var printQuery = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

            using var commandForPrint = new SqlCommand(printQuery, connect);
            commandForPrint.Parameters.AddWithValue("@Id", inputId);
            var reader = commandForPrint.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["name"]} – {reader["Age"]} years old");
            }
        }
    }
}
