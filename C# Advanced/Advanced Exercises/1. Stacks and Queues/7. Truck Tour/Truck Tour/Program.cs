using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());

            var petrolPomps = new Queue<int>();

            for (int i = 0; i < numberInput; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var balansPomp = input[0] - input[1];
                petrolPomps.Enqueue(balansPomp);
            }

            var numberPomp = 0;
            var curentSum = -1;

            while (curentSum < 0)
            {
                curentSum = 0;
                if (numberPomp > 0)
                {
                    var pompForMove = petrolPomps.Dequeue();
                    petrolPomps.Enqueue(pompForMove);
                }
                foreach (var pomp in petrolPomps)
                {
                    curentSum += pomp;
                    if (curentSum < 0)
                    {
                        numberPomp++;
                        curentSum = -1;
                        break;
                    }
                }
            }

            Console.WriteLine(numberPomp);
        }
    }
}
