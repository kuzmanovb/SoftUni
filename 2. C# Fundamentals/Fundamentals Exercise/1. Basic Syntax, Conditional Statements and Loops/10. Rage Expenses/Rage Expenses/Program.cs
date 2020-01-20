using System;

namespace Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {

            int lostGame = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double kayboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double expens = 0;
            int count = 0;
            int counTwo = 0;

            for (int i = 1; i <= lostGame; i++)
            {
                if (i % 2 == 0)
                {
                    expens += headsetPrice;
                    count++;
                }
                if (i % 3 == 0)
                {
                    expens += mousePrice;
                    count++;
                }
                if (count == 2)
                {
                    expens += kayboardPrice;
                    counTwo++;
                }
                if (counTwo == 2)
                {
                    expens += displayPrice;
                    counTwo = 0;
                }

                count = 0;

            }

            Console.WriteLine($"Rage expenses: {expens:f2} lv.");

        }
    }
}
