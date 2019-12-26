using System;

namespace NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Matrix(num);

        }
        static void Matrix (int num)
        {

            for (int i = 0; i < num; i++)
            {
                for (int a = 0; a < num; a++)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
