using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Numbers_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                int serialNumber = i;
                int counter = 0;

                while (serialNumber > 0)
                {
                    double bit = serialNumber * 1.0 % 10;
                    if (number % bit == 0)
                    {
                        counter++;
                    }
                    serialNumber = serialNumber / 10;
                }

                if (counter == 4)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
