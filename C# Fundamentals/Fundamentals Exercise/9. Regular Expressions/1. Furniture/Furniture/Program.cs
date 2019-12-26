using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            var furniture = new List<string>();
            double spendMoney = 0;

            var reg = new Regex(@">>([A-Za-z]+)<<(\d+\.*\d*)!(\d+)");

            string input = Console.ReadLine();

            while (input != "Purchase")
            {

                if (reg.IsMatch(input))
                {
                    var matchesInput = reg.Match(input);

                    furniture.Add(matchesInput.Groups[1].Value);
                    spendMoney += double.Parse(matchesInput.Groups[2].Value) * double.Parse(matchesInput.Groups[3].Value);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (var item in furniture)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {spendMoney:f2}");
        }
    }
}
