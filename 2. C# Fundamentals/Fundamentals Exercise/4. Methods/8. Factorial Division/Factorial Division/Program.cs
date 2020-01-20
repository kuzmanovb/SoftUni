using System;

namespace Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double factorial1 = Factorial(num1);
            double factorial2 = Factorial(num2);

            double result = factorial1 / factorial2;

            Console.WriteLine($"{result:f2}");

        }

        static double Factorial(double num)
        {
            double factorial = num;

            double numForFactorial = num;

            if (num != 0 && num != 1)
                while (numForFactorial > 1)
                {
                    {
                        factorial *= numForFactorial - 1;
                        numForFactorial -= 1;
                    }
                }
            else
            {
                factorial = 1;
            }
            return factorial;
        }
    }
}
