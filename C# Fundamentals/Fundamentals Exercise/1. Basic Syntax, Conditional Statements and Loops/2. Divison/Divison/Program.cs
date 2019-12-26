using System;

namespace Divison
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int numDivison = 0;

            if (number % 2 == 0)
            {
                numDivison = 2;
            }
            if (number % 3 == 0)
            {
                numDivison = 3;
            }
            if (number % 6 == 0)
            {
                numDivison = 6;
            }
            if (number % 7 == 0)
            {
                numDivison = 7;
            }
            if (number % 10 == 0)
            {
                numDivison = 10;
            }

            if (numDivison > 0)
            {
                Console.WriteLine($"The number is divisible by {numDivison}");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }

        }
    }
}
