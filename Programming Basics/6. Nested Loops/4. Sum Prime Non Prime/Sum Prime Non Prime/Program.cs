using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = true;

            int sumPrime = 0;
            int sumNoPrime = 0;

            while (end)
            {
                int counter = 0;
                string number = Console.ReadLine();
                if (number == "stop")
                {
                    end = false;
                    break;
                }
                int numberToInt = int.Parse(number);
                if (numberToInt < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                for (int i = 1; i <= numberToInt; i++)
                {
                    bool prime = numberToInt % i == 0;
                    if (prime)
                    {
                        counter++;
                    }
                }
                if (counter == 2)
                {
                    sumPrime += numberToInt;
                }
                else
                {
                    sumNoPrime += numberToInt;
                }

            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNoPrime}");
        }
    }
}
