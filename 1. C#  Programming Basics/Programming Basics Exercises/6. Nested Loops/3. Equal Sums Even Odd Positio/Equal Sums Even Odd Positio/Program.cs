using System;

namespace Equal_Sums_Even_Odd_Positio
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            for (int i = number1; i <= number2; i++)
            {
                int num1 = i / 100000;
                int num2 = i / 10000 % 10;
                int num3 = i / 1000 % 10;
                int num4 = i / 100 % 10;
                int num5 = i / 10 % 10;
                int num6 = i % 10;

                if (num1 + num3 + num5 == num2 + num4 + num6)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
