using System;
using System.Linq;

namespace Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int n = int.Parse(Console.ReadLine());

            int[] array2 = new int[array1.Length];

            for (int y = 0; y < n; y++)
            {

                for (int i = 0; i < array1.Length - 1; i++)
                {
                    array2[i] = array1[i + 1];

                }
                array2[array2.Length - 1] = array1[0];
                Array.Copy(array2, array1, array2.Length);
            }

            Console.WriteLine(string.Join(" ", array1));
        }
    }
}
