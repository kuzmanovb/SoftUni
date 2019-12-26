using System;
using System.Linq;

namespace Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            foreach (var item in input)
            {
                bool validUser = true;
                if (item.Length >= 3 && item.Length < 17)
                {
                    foreach (char userChar in item)
                    {

                        bool validChar = char.IsDigit(userChar) || char.IsLetter(userChar) || userChar == '-' || userChar == '_';
                        if (!validChar)
                        {
                            validUser = false;
                            break;
                        }
                    }
                    if (validUser)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}
