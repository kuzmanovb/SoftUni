using System;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            var rg = new Regex(@"(?<=\s)[A-Za-z0-9]+[\.-]?[A-Za-z0-9]*@[A-Za-z][A-Za-z-\.]+\.([A-za-z]+)\b");

            var validEmails = rg.Matches(input);

            foreach  (Match email in validEmails)
            {
                Console.WriteLine(email.Value);
            }
        }
    }
}
