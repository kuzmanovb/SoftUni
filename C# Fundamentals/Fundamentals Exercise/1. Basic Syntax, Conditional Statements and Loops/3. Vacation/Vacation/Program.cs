using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numGroup = int.Parse(Console.ReadLine());
            string typeGrup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double price = 0;

            if (typeGrup == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 10.46;
                }
            }
            else if(typeGrup == "Business")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 10.90;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 15.60;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 16.00;
                }
            }
            else if(typeGrup == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 15.00;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 20.00;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 22.50;
                }
            }


            double totalPrice = numGroup * price;

            if (typeGrup == "Students" && numGroup >= 30)
            {
                totalPrice = totalPrice * 0.85;
            }
            else if (typeGrup == "Business" && numGroup >= 100)
            {
                totalPrice -= 10 * price;
            }
            else if (typeGrup == "Regular" && numGroup >= 10 && numGroup <= 20)
            {
                totalPrice = totalPrice * 0.95;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
