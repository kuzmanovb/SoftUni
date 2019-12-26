using System;
using System.Text.RegularExpressions;

namespace Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"U\$([A-Z][a-z]{2,})U\$P@\$([A-Za-z0-9]+[0-9])P@\$");

            int numberEmail = int.Parse(Console.ReadLine());
            int countRegister = 0;

            for (int i = 0; i < numberEmail; i++)
            {
                string email = Console.ReadLine();

                var matchEmail = regex.Match(email);
                int countLetters = 0;

                foreach (var item in matchEmail.Groups[2].Value)
                {
                    if (char.IsLetter(item))
                    {
                        countLetters++;
                    }
                }

                if (matchEmail.Success && countLetters >= 5)
                {

                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {matchEmail.Groups[1].Value}, Password: {matchEmail.Groups[2].Value}");
                    countRegister++;

                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {countRegister}");

        }
    }
}
