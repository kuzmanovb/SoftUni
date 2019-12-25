using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameActior = Console.ReadLine();
            double pointAcademy = double.Parse(Console.ReadLine());
            int jury = int.Parse(Console.ReadLine());
            bool stop = false;

            double allPoint = pointAcademy;

            for (int i = 0; i < jury; i++)
            {
                string nameJury = Console.ReadLine();
                double pointJury = double.Parse(Console.ReadLine());
                double pointName = nameJury.Length;

                double point = pointName * pointJury / 2;

                allPoint += point;
                if (allPoint > 1250.5)
                {
                    stop = true;
                    break;
                }
            }

            if (stop)
            {
                Console.WriteLine($"Congratulations, {nameActior} got a nominee for leading role with {allPoint:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {nameActior} you need {1250.5 - allPoint:f1} more!");
            }
        }
    }
}
