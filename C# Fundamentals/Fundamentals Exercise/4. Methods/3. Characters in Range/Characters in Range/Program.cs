using System;

namespace Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());

            CharactersInRange(Math.Min((int)a,(int)b), Math.Max((int)a,(int)b));
        }
        static void CharactersInRange(int a, int b)
        {
            for (int i = a+1; i < b; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
