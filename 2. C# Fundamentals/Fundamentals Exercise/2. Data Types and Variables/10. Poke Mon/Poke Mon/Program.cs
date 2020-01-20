using System;

namespace Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            double divideTarget = n * 0.5;
            int target = 0;

            while (n >= m)
            {
                if (y > 0)
                {

                    if (n == divideTarget)
                    {
                        n = n / y;
                    }
                    if (n < m)
                    {
                        break;
                    }
                }
                n = n - m;
                target++;

            }

            Console.WriteLine(n);
            Console.WriteLine(target);


        }
    }
}
