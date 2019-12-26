using System;
using System.Linq;

namespace Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            var playerTwo = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (playerOne.Count > 0 && playerTwo.Count > 0)
            {
                int cardPlayerOne = playerOne[0];
                int cardPlayerTwo = playerTwo[0];

                if (cardPlayerOne == cardPlayerTwo)
                {
                    playerOne.RemoveAt(0);
                    playerTwo.RemoveAt(0);
                }
                else if (cardPlayerOne > cardPlayerTwo)
                {
                    playerOne.RemoveAt(0);
                    playerTwo.RemoveAt(0);
                    playerOne.Add(cardPlayerOne);
                    playerOne.Add(cardPlayerTwo);
                }
                else
                {
                    playerOne.RemoveAt(0);
                    playerTwo.RemoveAt(0);
                    playerTwo.Add(cardPlayerTwo);
                    playerTwo.Add(cardPlayerOne);
                }
            }

            if (playerOne.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {playerOne.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {playerTwo.Sum()}");
            }

        }
    }
}
