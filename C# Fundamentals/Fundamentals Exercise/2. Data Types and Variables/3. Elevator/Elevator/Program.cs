using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            double curses = Math.Ceiling(people * 1.0 / capacity);

            Console.WriteLine(curses);
        }
    }
}
