using System;
using System.Collections.Generic;

namespace A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {

            var miner = new Dictionary<string, int>();

            string inputKay = Console.ReadLine();

            while (inputKay != "stop")
            {
                int inputValue = int.Parse(Console.ReadLine());

                if (miner.ContainsKey(inputKay))
                {
                    miner[inputKay] += inputValue;
                }
                else
                {
                    miner.Add(inputKay, inputValue);
                }
                
                inputKay = Console.ReadLine();
            }

            foreach (var item in miner)
            {
                Console.WriteLine(item.Key + " -> "+ item.Value);
            }

        }
    }
}
