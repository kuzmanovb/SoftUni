using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string aniFavouritBook = Console.ReadLine();
            int bookNumber = int.Parse(Console.ReadLine());
            int bookCheck = 0;

            while (bookNumber > bookCheck)
            {
                string search = Console.ReadLine();
                if (aniFavouritBook == search)
                {
                    Console.WriteLine($"You checked {bookCheck} books and found it.");
                    return;
                }
                bookCheck++;

            }
            Console.WriteLine($"The book you search is not here!");
            Console.WriteLine($"You checked {bookCheck} books.");


        }
    }
}
