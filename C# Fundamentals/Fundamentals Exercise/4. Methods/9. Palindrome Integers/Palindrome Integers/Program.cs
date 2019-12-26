using System;
using System.Linq;

namespace Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            while (num != "END")
            {
                string palindrome = PalindromeIntegers(num);

                if (num == palindrome)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                num = Console.ReadLine();
            }

        }
        static string PalindromeIntegers(string num)
        {
            char[] palidrome = num.ToCharArray();
            Array.Reverse(palidrome);

            return new string(palidrome);
        }
    }
}
