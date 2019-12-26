using System;
using System.Text;
using System.Linq;

namespace Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberInput = Console.ReadLine().TrimStart('0');
            char[] number = numberInput.ToCharArray(); ;
            int multiNumber = int.Parse(Console.ReadLine());

            if (multiNumber == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                var bigNumber = new StringBuilder();

                int numForAdd = 0;

                for (int i = number.Length - 1; i >= 0; i--)
                {
                    int numFromNumber = number[i] - 48;
                    int numMulty = numFromNumber * multiNumber + numForAdd;
                    if (i == 0)
                    {
                        bigNumber.Insert(0, numMulty);
                    }
                    else
                    {
                        bigNumber.Insert(0, numMulty % 10);
                        numForAdd = numMulty / 10;
                    }

                }
                Console.WriteLine(bigNumber);
            }

        }
    }
}
