using System;

namespace Print_Part_of_the_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int star = int.Parse(Console.ReadLine());
            int stop = int.Parse(Console.ReadLine());

            for (int i = star; i <= stop; i++)
            {
                char b = (char)i;
                Console.Write(b+" ");
            }

        }
    }
}
