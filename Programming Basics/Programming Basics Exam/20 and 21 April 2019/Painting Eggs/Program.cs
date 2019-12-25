using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string sizeEggs = Console.ReadLine();
            string colorEggs = Console.ReadLine();
            int lotEggs = int.Parse(Console.ReadLine());

            double price = 0;

            if (sizeEggs == "Large")
            {
                switch (colorEggs)
                {
                    case "Red": price = 16.00;break;
                    case "Green": price = 12.00;break;
                    case "Yellow": price = 9.00;break;
                }
            }
            else if (sizeEggs == "Medium")
            {
                switch (colorEggs)
                {
                    case "Red": price = 13.00; break;
                    case "Green": price = 9.00; break;
                    case "Yellow": price = 7.00; break;
                }
            }
            else if (sizeEggs == "Small")
            {
                switch (colorEggs)
                {
                    case "Red": price = 9.00; break;
                    case "Green": price = 8.00; break;
                    case "Yellow": price = 5.00; break;
                }

            }
            double finishPrice = (lotEggs * price) * 0.65;

            Console.WriteLine($"{finishPrice:f2} leva.");

        }
    }
}
