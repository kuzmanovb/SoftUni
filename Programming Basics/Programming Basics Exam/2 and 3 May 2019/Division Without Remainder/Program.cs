using System;

namespace Division_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int p2 = 0;
            int p3 = 0;
            int p4 = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    p2++;
                }
                if (number % 3 == 0)
                {
                    p3++;
                }
                if (number % 4 == 0)
                {
                    p4++;
                }
            }

            Console.WriteLine($"{(p2 * 1.0) / n * 100.0:f2}%");
            Console.WriteLine($"{(p3 * 1.0) / n * 100.0:f2}%");
            Console.WriteLine($"{(p4 * 1.0) / n * 100.0:f2}%");
        }
    }
}
