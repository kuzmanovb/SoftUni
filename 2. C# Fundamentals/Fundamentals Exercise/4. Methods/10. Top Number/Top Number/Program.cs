using System;

namespace Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {

                if (HaveOddDigit(i) && SumOfDigit(i) % 8 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool HaveOddDigit (int num)
        {
            bool haveOdd = false;

            int numForCheck = num;

            while (numForCheck > 0)
            {
                int numMedial = numForCheck % 10;
                if (numMedial % 2 != 0)
                {
                    haveOdd = true;
                    break;
                }
                numForCheck /= 10;
            }
            return haveOdd;
        }

        static int SumOfDigit (int num)
        {
            int sum = 0;

            int numForCheck = num;

            while (numForCheck > 0)
            {
                sum += numForCheck % 10;
               
                numForCheck /= 10;
            }

            return sum;
        }
    }
}
