using System;
using System.Collections.Generic;
using System.Linq;

namespace Wizard_Poker
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] card = Console.ReadLine().Split(":");

            var deck = new List<string>();

            string input = Console.ReadLine();

            while (input != "Ready")
            {
                string[] inputArr = input.Split();
                string command = inputArr[0];

                if (command == "Add")
                {
                    if (card.Contains(inputArr[1]))
                    {
                        deck.Add(inputArr[1]);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(inputArr[2]);
                    bool checkIndex = index >= 0 && index <= deck.Count;

                    if (card.Contains(inputArr[1]) && checkIndex)
                    {
                        deck.Insert(index, inputArr[1]);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
                else if (command == "Remove")
                {
                    if (deck.Contains(inputArr[1]))
                    {
                        deck.Remove(inputArr[1]);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (command == "Swap")
                {
                    string cardOne = inputArr[1];
                    string cardTwo = inputArr[2];

                    int indexOne = deck.IndexOf(cardOne);
                    int indexTwo = deck.IndexOf(cardTwo);

                    deck[indexOne] = cardTwo;
                    deck[indexTwo] = cardOne;
                }
                else if (command == "Shuffle")
                {
                    deck.Reverse();
                }
               
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", deck));
            
        }
    }
}
