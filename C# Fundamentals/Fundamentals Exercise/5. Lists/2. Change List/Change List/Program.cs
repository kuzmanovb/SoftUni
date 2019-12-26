using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var integerList = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] input = command.Split();

                if (input[0] == "Delete")
                {
                    int num = int.Parse(input[1]);

                    for (int i = 0; i < integerList.Count; i++)
                    {
                        if (integerList[i] == num)
                        {
                            integerList.Remove(num);
                            i = i - 1;
                        }
                    }
                }
                else if (input[0] == "Insert")
                {
                    int item = int.Parse(input[1]);
                    int index = int.Parse(input[2]);

                    integerList.Insert(index, item);

                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", integerList));

        }
    }
}
