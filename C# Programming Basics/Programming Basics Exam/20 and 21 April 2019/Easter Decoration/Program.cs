using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int customers = int.Parse(Console.ReadLine());

            int customersNumber = 0;
            double allOrderSum = 0;

            for (int i = 0; i < customers; i++)
            {
                double OrderSum = 0;
                int orderNumber = 0;
                while (true)
                {
                    string decoration = Console.ReadLine();
                    if (decoration == "Finish")
                    {
                        customersNumber++;
                        if (orderNumber % 2 == 0)
                        {
                            OrderSum = OrderSum * 0.8;
                        }
                        allOrderSum += OrderSum;

                        Console.WriteLine($"You purchased {orderNumber} items for {OrderSum:f2} leva.");
                        break;
                    }
                    else
                    {
                        switch (decoration)
                        {
                            case "basket": OrderSum += 1.50; orderNumber++; break;
                            case "wreath": OrderSum += 3.80; orderNumber++; break;
                            case "chocolate bunny": OrderSum += 7.00; orderNumber++; break;

                        }
                    }

                }

            }
            Console.WriteLine($"Average bill per client is: {allOrderSum / customersNumber:f2} leva.");

        }
    }
}
