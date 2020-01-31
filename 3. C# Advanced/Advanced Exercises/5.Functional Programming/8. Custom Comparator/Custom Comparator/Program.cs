using System;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(inputNumbers, new Comparison<int>(Comparator));

            Console.WriteLine(string.Join(" ", inputNumbers));

        }

        static int Comparator(int a, int b)
        {

            if (a % 2 == 0 && b % 2 != 0)
            {
                return -1;
            }
            else if (a % 2 != 0 && b % 2 == 0)
            {
                return 1;
            }
            else
            {
                return a.CompareTo(b);
            }

        }
    }
}
