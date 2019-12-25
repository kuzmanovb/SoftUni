using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacityHall = int.Parse(Console.ReadLine());

            int income = 0;
            bool stop = false;

            while (true)
            {
                string enter = Console.ReadLine();
                if (enter == "Movie time!")
                {
                    stop = true;
                    break;
                }

                int people = int.Parse(enter);

                capacityHall = capacityHall - people;
                if (capacityHall < 0)
                {
                    break;
                }

                income = income + (people * 5);
                if (people % 3 == 0)
                {
                    income = income - 5;
                }
            }

            if (stop)
            {
                Console.WriteLine($"There are {capacityHall} seats left in the cinema.");
            }
            else
            {
                Console.WriteLine("The cinema is full.");
            }

            Console.WriteLine($"Cinema income - {income} lv.");


        }
    }
}
