using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int lenghtNumber = number.Length;

            int numberToInt = int.Parse(number);

            for (int i = 0; i < lenghtNumber; i++)
            {
                int curentNumber = numberToInt % 10;
                if (curentNumber == 0)
                {
                    Console.WriteLine("ZERO");
                }
                else
                {
                char symbol = (char)(curentNumber + 33);
                Console.WriteLine(new string (symbol, curentNumber));
                }
                numberToInt = numberToInt / 10;

            }
            

        }
    }
}
