using System;
using System.Text.RegularExpressions;
using System.Text;

namespace Password2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());
            var patern = new Regex (@"^(.+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<(\1)$");
            
            for (int i = 0; i < numberInput; i++)
            {
                string input = Console.ReadLine();
                var matchPassword = patern.IsMatch(input);


                if (matchPassword)
                {
                    StringBuilder sb = new StringBuilder();
                    var password = patern.Match(input);

                    sb.Append(password.Groups[2].Value);
                    sb.Append(password.Groups[3].Value);
                    sb.Append(password.Groups[4].Value);
                    sb.Append(password.Groups[5].Value);

                    Console.WriteLine($"Password: {sb.ToString()}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
