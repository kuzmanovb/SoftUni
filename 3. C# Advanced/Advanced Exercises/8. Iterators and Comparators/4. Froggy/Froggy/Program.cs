using System;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            var newLake = new Lake(input);

            Console.WriteLine(string.Join(", ", newLake));
        }
    }
}
