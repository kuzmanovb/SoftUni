using System;

namespace Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            int point = int.Parse(Console.ReadLine());
            double bonus = 0;
            if (point % 2 == 0)
            {
                bonus += 1;
            }
            if (point % 10 == 5)
            {
                bonus += 2;
            }
            if (point <= 100)
            {
                bonus += 5;
            }
            else if (point > 100 && point <= 1000)
            {
                bonus += point * 0.2;
            }
            else
            {
                bonus += point * 0.1;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(point + bonus);
        }
    }
}
