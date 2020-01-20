using System;

namespace Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int a  = 97; a  < 97 + n; a ++)
            {
                for (int b = 97; b < 97 + n; b++)
                {
                    for (int c = 97; c < 97 + n; c++)
                    {

                        Console.Write((char)a);
                        Console.Write((char)b);
                        Console.Write((char)c);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
