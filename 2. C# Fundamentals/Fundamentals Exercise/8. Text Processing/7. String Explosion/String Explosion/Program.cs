using System;
using System.Linq;

namespace String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray().ToList();
            int add = 0;
            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i] == '>' && char.IsDigit(input[i + 1]))
                {
                    int number = input[i+1]-48 + add;
                    int numberForSubtrack = input[i+1]-48 + add;
                    if (number + i > input.Count-1)
                    {
                        number = (input.Count - 1) - i;
                        numberForSubtrack = (input.Count - 1) - i;
                    }
                    for (int y = i+1; y <= i + number; y++)
                    {
                        if (input[y] == '>')
                        {
                            add = i + numberForSubtrack - y;
                            break;
                        }
                        else
                        {
                            input.RemoveAt(y);
                            y--;
                            number--;
                        }
                    }

                }
            }
            Console.WriteLine(string.Join("",input));
        }
    }
}
