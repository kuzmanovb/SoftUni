using System;

namespace Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            Result(a, b, c);

        }
        static void Result(int a, int b, int c)
        {
            int result = a + b - c;

            Console.WriteLine(result);
        }
    }
}
