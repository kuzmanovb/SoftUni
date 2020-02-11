﻿using System;
using System.Linq;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            // <<first name> <last name>> <address> <town>
            var input = Console.ReadLine().Split();
            var name = $"{input[0]} {input[1]}";
            var address = input[2];
            var town = input[3];
            Console.WriteLine(new Threeuple<string, string, string>(name, address, town));

            // <name> <liters of beer> <drunk or not>
            input = Console.ReadLine().Split();
            name = input[0];
            var beerLiterrs = int.Parse(input[1]);
            var drunkOrNot = input[2] == "drunk";
            Console.WriteLine(new Threeuple<string, int, bool>(name, beerLiterrs, drunkOrNot));

            // <name> <account balance> <bank name>
            input = Console.ReadLine().Split();
            name = input[0];
            var accountBalance = double.Parse(input[1]); 
            var bankName = input[2];
            Console.WriteLine(new Threeuple<string, double, string>(name, accountBalance, bankName));
        }
    }
}
