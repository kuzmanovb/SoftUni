using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int current = 1;

            for (int rows = 1; rows <= number; rows++)
            {
                if (current > number)
                {
                    break;
                }
                for (int cols = 1; cols <= rows; cols++)
                {
                if (current > number)
                {
                    break;
                }
                    Console.Write(current + " ");
                    current++;
                }
                Console.WriteLine();
            }

        }
    }
}
