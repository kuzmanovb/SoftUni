using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {

            double sum = double.Parse(Console.ReadLine());

            double sum1 = Math.Floor(sum) ;
            double sum2 = Math.Floor((sum * 100) % 100);

            int coins = 0; 

            while (sum1 > 0)
            {
                if (sum1 - 2 >= 0)
                {
                    sum1 -= 2;
                    coins++;
                }
                else if (sum1 - 1 >= 0)
                {
                    sum1 -= 1;
                    coins++;
                }

            }
            while (sum2 > 0)
            {
                if (sum2 - 50 >= 0)
                {
                    sum2 -= 50;
                    coins++;
                }
                else if (sum2 - 20 >= 0)
                {
                    sum2 -= 20;
                    coins++;
                }
                else if (sum2 - 10 >= 0)
                {
                    sum2 -= 10;
                    coins++;
                }
                else if (sum2 - 5 >= 0)
                {
                    sum2 -= 5;
                    coins++;
                }
                else if (sum2 - 2 >= 0)
                {
                    sum2 -= 2;
                    coins++;
                }
                else if (sum2 - 1 >= 0)
                {
                    sum2 -= 1;
                    coins++;
                }
            }
            Console.WriteLine(coins);
        }
    }
}
