using System;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] trainWagons = new int[n];
            int allPeople = 0;

            for (int i = 0; i < n; i++)
            {
                int peopleInWagon = int.Parse(Console.ReadLine());
                trainWagons[i] = peopleInWagon;
                allPeople += peopleInWagon;
            }

            Console.WriteLine(string.Join(" ", trainWagons));
            Console.WriteLine(allPeople);
        }
    }
}
