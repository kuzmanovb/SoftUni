using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^!([A-Z][a-z]{2,})!\:\[([A-Za-z]{8,})\]$");

            int numberInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInput; i++)
            {
                string input = Console.ReadLine();

                var checkInpur = regex.Match(input);

                if (checkInpur.Success)
                {
                    var encrypt = new List<int>();

                    foreach (var item in checkInpur.Groups[2].Value)
                    {
                        encrypt.Add(item);
                    }

                    string finishEncrypt = string.Join(" ", encrypt);
                    string name = checkInpur.Groups[1].Value;
                    Console.WriteLine($"{name}: {finishEncrypt}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
