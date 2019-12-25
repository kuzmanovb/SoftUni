using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameFilm = Console.ReadLine();
            int numberDay = int.Parse(Console.ReadLine());
            int numberTicket = int.Parse(Console.ReadLine());
            double priceTicket = double.Parse(Console.ReadLine());
            double procentForKino = double.Parse(Console.ReadLine());

            double allSum = (numberTicket * priceTicket) * numberDay;
            double procentSum = allSum * procentForKino / 100;
            double totalPrice = allSum - procentSum;

            Console.WriteLine($"The profit from the movie {nameFilm} is {totalPrice:f2} lv.");

        }
    }
}
