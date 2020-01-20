using System;

namespace Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int minLength = Math.Min(input[0].Length, input[1].Length);

            string inputEnd = input[0].Substring(minLength) + input[1].Substring(minLength);
            
            int sum = 0;

            for (int i = 0; i < minLength; i++)
            {
                int charOne = input[0][i];
                int charTwo = input[1][i];
                sum += charOne * charTwo;
            }

            foreach (var item in inputEnd)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }
    }
}
