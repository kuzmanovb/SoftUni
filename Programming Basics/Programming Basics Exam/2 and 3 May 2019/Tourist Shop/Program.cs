using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourist_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double budgetDoun = budget;
           double productNumber = 0;
           double allPrice = 0;

            while (true)
            {
                string productName = Console.ReadLine();

                if (productName == "Stop")
                {
                    Console.WriteLine($"You bought {productNumber} products for {allPrice:f2} leva.");
                    break;
                }

                double productPrice = double.Parse(Console.ReadLine());

                productNumber++;

                if (productNumber % 3 == 0 && productNumber != 0)
                {
                    allPrice += productPrice / 2;
                    budgetDoun -= productPrice / 2;

                }
                else
                {
                    allPrice += productPrice;
                    budgetDoun -= productPrice;
                }


                if (allPrice > budget)
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {Math.Abs(budgetDoun):f2} leva!");
                    break;
                }
            }

        }
    }
}
