using System;
using System.Collections.Generic;
using System.Linq;

namespace Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int sumAll = 0;
            int checkNum = int.Parse(number);
            int numberOne = int.Parse(number);

            for (int i = 0; i < number.Length; i++)
            {
                int curentNumber = numberOne % 10;
                int sum = curentNumber;

                for (int a = curentNumber - 1; a >= 1; a--)
                {
                    sum = sum * a;
                }

                sumAll += sum;
                numberOne = numberOne / 10;
            }

            if (checkNum == sumAll)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
