using System;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int sum = 0;

            while (number > 0)
            {
                int numberSum = number % 10;
                number = number / 10;
                sum += numberSum;

            }

            Console.WriteLine(sum);
        }
    }
}
