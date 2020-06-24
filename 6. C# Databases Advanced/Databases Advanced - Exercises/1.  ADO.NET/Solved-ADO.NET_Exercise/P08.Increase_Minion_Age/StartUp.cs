using System;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace P08.Increase_Minion_Age
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var connect = new SqlConnection(@"Server = BIBI-PC\SQLEXPRESS; Database = MinionsDB; Integrated Security = true");
            connect.Open();

            var inputId = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var increaseQuery = @" UPDATE Minions
                                   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                    WHERE Id = @Id";

            foreach (var Id in inputId)
            {
                using var command = new SqlCommand(increaseQuery, connect);
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();
            }

            var printQuery = @"SELECT Name, Age FROM Minions";
            using var commandForPrint = new SqlCommand(printQuery, connect);
            var reader = commandForPrint.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
            }
        }
    }
}
