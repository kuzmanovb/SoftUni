using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());

            int allCake = length * width;
            int pieceOfCake = 0;

            while (pieceOfCake <= allCake)
            {
                string input = Console.ReadLine();
                if (input == "STOP")
                {
                    Console.WriteLine($"{allCake - pieceOfCake} pieces are left.");
                    return;
                }
                pieceOfCake += int.Parse(input);

            }










            Console.WriteLine($"No more cake left! You need {pieceOfCake - allCake} pieces more.");
        }
    }
}
