using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepForDay = 0;

            while (stepForDay < 10000)
            {

                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    int inputFinal = int.Parse(Console.ReadLine());
                    stepForDay += inputFinal;
                    break;
                }
                else
                {
                    stepForDay += int.Parse(input);
                }
            }

            if (stepForDay >= 10000)
            {
                Console.WriteLine($"Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{10000 - stepForDay} more steps to reach goal.");
            }

        }
    }
}
