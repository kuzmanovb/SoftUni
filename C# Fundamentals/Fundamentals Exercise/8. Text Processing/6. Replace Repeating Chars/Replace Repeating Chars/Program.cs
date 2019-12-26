using System;
using System.Text;

namespace Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var str = new StringBuilder();
            char match = default;

            foreach (var item in input)
            {
                if (match != item)
                {
                    match = item;
                    str.Append(item);
                }
            }

            Console.WriteLine(str);

        }
    }
}
