using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {

            int greenLinghtTime = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            var totalCars = 0;

            var queueCars = new Queue<string>();

            var command = Console.ReadLine();
            var check = true;
            string crashCar = null;

            while (command != "END")
            {
                if (command == "green" && check)
                {
                    var curentGreenTime = greenLinghtTime;
                    var curentFreeTime = freeWindow;
                    while (curentGreenTime > 0 && queueCars.Any())
                    {
                        var curentCar = queueCars.Dequeue();
                        var curentCarQueue = new Queue<char>(curentCar);
                        totalCars++;
                        while (curentGreenTime > 0 && curentCarQueue.Any())
                        {
                            curentCarQueue.Dequeue();
                            curentGreenTime--;
                        }
                        while (curentGreenTime == 0 && curentFreeTime > 0 && curentCarQueue.Any())
                        {
                            curentCarQueue.Dequeue();
                            curentFreeTime--;
                        }
                        if (curentCarQueue.Any())
                        {
                            check = false;
                            crashCar = $"{curentCar} was hit at {curentCarQueue.Dequeue()}.";
                            break;
                        }
                    }
                }
                else
                {
                    queueCars.Enqueue(command);
                }
                command = Console.ReadLine();
            }

            if (check)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCars} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine(crashCar);
            }
        }
    }
}
