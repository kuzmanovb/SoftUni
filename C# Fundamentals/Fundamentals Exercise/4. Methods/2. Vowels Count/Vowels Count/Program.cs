using System;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(VowelsCount(input));
        }

        static int VowelsCount(string name)
        {
            char[] nameArray = name.ToCharArray();
            int vowelsSum = 0;

            foreach (var letter in nameArray)
            {
                bool vowelLower = letter =='a' || letter == 'e' || letter == 'i' || letter =='o' || letter =='u';
                bool vowelUpper = letter == 'A' || letter == 'E' || letter =='I' || letter == 'O' || letter =='U';

                if (vowelLower || vowelUpper)
                {
                    vowelsSum++;
                }
            }

            return vowelsSum;
        }
    }
}
