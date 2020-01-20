using System;
using System.Collections.Generic;
using System.Linq;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] passtArrey = Console.ReadLine().ToArray();
            char[] reversArrey = passtArrey.Reverse().ToArray();

            string passwordCorrect = new string(passtArrey);
            string password = new string(reversArrey);

            int count = 0;
            bool end = true;

            string checkPasst = Console.ReadLine();

            while (password != checkPasst)
            {
                if (count < 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    checkPasst = Console.ReadLine();
                    count++;
                }
                else
                {
                    Console.WriteLine($"User {passwordCorrect} blocked!");
                    end = false;
                    break;
                }
            }
            if (end)
            {
                Console.WriteLine($"User {passwordCorrect} logged in.");

            }
        }
    }
}
