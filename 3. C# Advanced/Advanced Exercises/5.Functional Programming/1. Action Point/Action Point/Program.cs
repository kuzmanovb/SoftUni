using System;
using System.Linq;

namespace Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine(x);

            var names = Console.ReadLine().Split().ToList();
            names.ForEach(print);
        }
    }
}
