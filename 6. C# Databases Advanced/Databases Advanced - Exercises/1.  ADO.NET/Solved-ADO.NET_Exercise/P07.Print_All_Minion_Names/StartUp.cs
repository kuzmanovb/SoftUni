using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace P07.Print_All_Minion_Names
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using var connect = new SqlConnection(@"Server = BIBI-PC\SQLEXPRESS; Database = MinionsDB; Integrated Security = true");
            connect.Open();

            var getAllMinionsQuery = @"SELECT Name FROM Minions";
            using var commandGetMinions = new SqlCommand(getAllMinionsQuery, connect);
            var reade = commandGetMinions.ExecuteReader();

            var listMinions = new List<string>();

            while (reade.Read())
            {
                listMinions.Add(reade["name"].ToString()); ;
            }

            for (int i = 0; i < listMinions.Count / 2; i++)
            {
                Console.WriteLine(listMinions[i]);
                Console.WriteLine(listMinions[listMinions.Count - 1 - i]);
            }

            if (listMinions.Count % 2 != 0)
            {
                Console.WriteLine(listMinions[listMinions.Count / 2]);
            }
        }
    }
}
