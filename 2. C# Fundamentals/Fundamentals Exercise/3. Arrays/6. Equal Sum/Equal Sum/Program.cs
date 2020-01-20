using System;
using System.Linq;

namespace Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] imput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int leftSum = 0;
            int ringhtSum = imput.Sum();

            for (int i = 0; i < imput.Length; i++)
            {
                ringhtSum -= imput[i];

                if (leftSum == ringhtSum)
                {
                    Console.WriteLine(i);
                    break;
                }
                leftSum += imput[i];
            }

            if (leftSum != ringhtSum)
            {
                Console.WriteLine("no");
            }
        }
    }
}
