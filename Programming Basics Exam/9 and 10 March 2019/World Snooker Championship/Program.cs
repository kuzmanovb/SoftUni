using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Snooker_Championship
{
    class Program
    {
        static void Main(string[] args)
        {

            //Вход
            //От конзолата се четат 3 реда:
            //1.Етап на първенството – текст - “Quarter final ”, “Semi final” или “Final”
            //2.Вид на билета – текст - “Standard”, “Premium” или “VIP”
            //3.Брой билети – цяло число в интервала[1 … 30]
            //4.Снимка с трофея – символ – 'Y'(да) или 'N'(не)
            //Изход
            //На конзолата се отпечатва 1 ред:
            //•	"Цената, която трябва да се заплати, форматирана до втората цифра след десетичния знак"

            string round = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int ticketNumber = int.Parse(Console.ReadLine());
            string picture = Console.ReadLine();
            double ticketPrice = 0;

            if (round == "Quarter final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = 55.50;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = 105.20;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = 118.90;
                }

            }
            else if (round == "Semi final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = 75.88;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = 125.22;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = 300.40;
                }
            }
            else if (round == "Final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = 110.10;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = 160.66;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = 400;
                }
            }
          
            double price = ticketNumber * ticketPrice;


            if (price > 4000)
            {
                double all = price * 0.75;
                
                    Console.WriteLine($"{all:f2}");

            }
            else if (price > 2500 && price <= 4000)
            {
                double all = price * 0.9;
                if (picture == "Y")
                {
                Console.WriteLine($"{all + (ticketNumber * 40):f2}" );

                }
                else if (picture == "N")
                {
                    Console.WriteLine($"{all:f2}" );
                }

            }
            else
            {
                if (picture == "Y")
                {
                    Console.WriteLine($"{price + (ticketNumber * 40):f2}");

                }
                else if (picture == "N")
                {
                    Console.WriteLine($"{price:f2}");
                }
              
            }

        }
    }
            //При избрана опция за снимки с трофея, цената се начислява след изчисляването на отстъпките.
}
            //При закупуване на билет, зрителят може да избере опция, снимка с трофея, на цена 40 лири.
            //При достигане на определена сума има отстъпки:
            //•	Над 4000 лири има 25 % отстъпка и безплатни снимки с трофея(ако  опцията за снимки е избрана, таксата от 40 лири за билет не се включва)
            //•	Над 2500 лири има 10 % отстъпка
