using System;

namespace Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(SmallestOfThreeNumbers(num1, num2, num3));
        }

        static int SmallestOfThreeNumbers(int num1, int num2, int num3)
        {
            if (num1 > num2)
            {
                if (num2 > num3)
                {
                    return num3;
                }
                else
                {
                    return num2;
                }
            }
            else
            {
                if (num1 > num3)
                {
                    return num3;
                }
                else
                {
                    return num1;
                }
            }
        }

    }
}
