using System;
using System.Linq;

namespace Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombEndPower = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bombNumber = bombEndPower[0];
            int power = bombEndPower[1];

            for (int i = 0; i < number.Count; i++)
            {
                int currentNum = number[i];

                if (currentNum == bombNumber)
                {
                    int moveForRemoveLeft = i + power;
                    if (moveForRemoveLeft > number.Count - 1)
                    {
                        moveForRemoveLeft = number.Count - 1;
                    }
                    for (int a = moveForRemoveLeft; a >= i + 1; a--)
                    {
                        number.RemoveAt(a);
                    }

                    number.RemoveAt(i);

                    int moveForRemoveRight = i - power;
                    if (moveForRemoveRight < 0)
                    {
                        moveForRemoveRight = 0;
                    }
                    for (int b = i - 1; b >= moveForRemoveRight; b--)
                    {
                        number.RemoveAt(b);
                    }

                    i -= (power * 2 + 1);
                    if (i < 0)
                    {
                        i = 0;
                    }
                }
            }
           
            Console.WriteLine(number.Sum());
        }
    }
}
