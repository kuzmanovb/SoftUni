using System;
using System.Text;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var newString = new StringBuilder();

            foreach (var item in input)
            {
                newString.Append((char)(item + 3));
            }

            Console.WriteLine(newString);
        }
    }
}
