using System;
using System.Linq;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayImput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int counter1 = 1;
            int counter2 = 1;
            int numForPrint = arrayImput[0];

            for (int i = 1; i < arrayImput.Length; i++)
            {
                int num1 = arrayImput[i - 1];
                int num2 = arrayImput[i];

                if (num1 == num2)
                {
                    counter1++;
                }
                if (counter2 < counter1)
                {
                    numForPrint = num1;
                    counter2 = counter1;
                }
                if (num1 != num2)
                {
                    counter1 = 1;
                }
            }

            for (int i = 0; i < Math.Max(counter2, counter1); i++)
            {
                Console.Write(numForPrint + " ");
            }
        }
    }
}
