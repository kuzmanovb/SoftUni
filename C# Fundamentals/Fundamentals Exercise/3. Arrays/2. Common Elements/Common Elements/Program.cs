using System;
using System.Linq;

namespace Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(' ').ToArray();
            string[] array2 = Console.ReadLine().Split(' ').ToArray();

            for (int i = 0; i < array2.Length; i++)
            {
                string elementArray2 = array2[i];

                for (int y = 0; y < array1.Length; y++)
                {
                    string elementArray1 = array1[y];

                    if (elementArray1 == elementArray2)
                    {
                        Console.Write(elementArray1 + " ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
