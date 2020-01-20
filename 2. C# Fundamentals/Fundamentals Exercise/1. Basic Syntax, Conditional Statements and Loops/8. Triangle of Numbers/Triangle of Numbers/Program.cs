using System;

namespace Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                for (int a  = 1; a  <= i; a ++)
                {
                    Console.Write(i + " ");
                }

                Console.WriteLine();

            }

        }
    }
}
