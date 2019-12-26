using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputBook = Console.ReadLine();
            string[] forReplace = Console.ReadLine().Split();
            
            var patern = @"^[d-z{}|#]+$";
            var rg = new Regex(patern);

            var sb = new StringBuilder();
            bool check = true;

            if (rg.IsMatch(inputBook))
            {
                foreach (var item in inputBook)
                {

                    sb.Append((char)(item - 3));
                }                
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
                check = false;
            }

            inputBook = sb.ToString();


            inputBook = inputBook.Replace(forReplace[0], forReplace[1]);
            
            if (check)
            {
                Console.WriteLine(inputBook);
            }

        }
    }
}
