using System;
using System.Collections.Generic;
using System.Linq;

namespace Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gift = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();

            while (input != "No Money")
            {
                string[] inputArray = input.Split();

                if (inputArray[0] == "OutOfStock")
                {
                    for (int i = 0; i < gift.Count; i++)
                    {
                        if (gift[i] == inputArray[1])
                        {
                            gift.Insert(i, "None");
                            gift.RemoveAt(i + 1);
                        }
                    }
                }
                else if (inputArray[0] == "Required")
                {
                    string giftForReplace = inputArray[1];
                    int index = int.Parse(inputArray[2]);

                    if (index >= 0 && index < gift.Count)
                    {
                        gift.Insert(index, giftForReplace);
                        gift.RemoveAt(index + 1);
                    }
                }
                else if (inputArray[0] == "JustInCase")
                {
                    string giftAdd = inputArray[1];

                    gift.RemoveAt(gift.Count - 1);
                    gift.Add(giftAdd);
                }

                input = Console.ReadLine();

            }

            for (int i = 0; i < gift.Count; i++)
            {
                if (gift[i] != "None")
                {
                    Console.Write(gift[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
