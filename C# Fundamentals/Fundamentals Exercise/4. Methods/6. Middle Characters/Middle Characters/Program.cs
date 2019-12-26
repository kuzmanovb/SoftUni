using System;

namespace Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(MiddleChar(input));

        }
        static string MiddleChar(string text)
        {
            int midleIndex = text.Length / 2;

            if (text.Length % 2 == 0)
            {
                string exit = text[midleIndex - 1].ToString() + text[midleIndex].ToString();

                return exit;
            }
            else
            {
                string exit = text[midleIndex].ToString();

                return exit;
            }
        }
    }
}
