using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P05.Change_Town_Names_Casing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var connect = new SqlConnection(@"Server = BIBI-PC\SQLEXPRESS; Database = MinionsDB; Integrated Security = true");
            connect.Open();

            var queryForChange = @"UPDATE Towns
                                   SET Name = UPPER(Name)
                                   WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            var countryName = Console.ReadLine();

            using var command = new SqlCommand(queryForChange, connect);
            command.Parameters.AddWithValue("@countryName", countryName);
            var affectedRow = command.ExecuteNonQuery();

            if (affectedRow == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{affectedRow} town names were affected.");

                var townsNameQuery = @" SELECT t.Name 
                                        FROM Towns as t
                                        JOIN Countries AS c ON c.Id = t.CountryCode
                                        WHERE c.Name = @countryName";

                using var commandPrintTowns = new SqlCommand(townsNameQuery, connect);
                commandPrintTowns.Parameters.AddWithValue("@countryName", countryName);
                var reader = commandPrintTowns.ExecuteReader();

                var sb = new StringBuilder();
                sb.Append("[");
                while (reader.Read())
                {
                    sb.Append($"{reader["name"]}, ");
                }

                char[] charsToTrim = { ',', ' ' };
                Console.WriteLine(sb.ToString().TrimEnd(charsToTrim) + "]");
            }
        }
    }
}
