using System;
using System.Collections.Generic;
using System.Linq;

namespace Vapor_Winter_Sale
{
    class Program
    {
        static void Main(string[] args)
        {

            var gamePrice = new Dictionary<string, double>();   
            var gameDlc = new Dictionary<string, string>();

            string[] input = Console.ReadLine().Split(", ");

            foreach (var game in input)
            {
                string[] gameArr = game.Split(new char[] { '-', ':' });

                bool checkPrice = true;
                
                foreach (var digit in gameArr[1])
                {
                    if (!char.IsDigit(digit) && digit != '.')
                    {
                        checkPrice = false;
                        break;
                    }
                }
               
                if (checkPrice)
                {
                    if (!gamePrice.ContainsKey(gameArr[0]))
                    {
                        gamePrice.Add(gameArr[0], 0);
                    }
                    gamePrice[gameArr[0]] += double.Parse(gameArr[1]);
                }
                else
                {

                    if (gamePrice.ContainsKey(gameArr[0]))
                    {
                        gameDlc.Add(gameArr[0], gameArr[1]);
                        gamePrice[gameArr[0]] *=  1.2; 
                    }
                }
            }
            var gameWhitDlc = new Dictionary<string, double>();
            var gameNoDlc = new Dictionary<string, double>();

            foreach (var game in gamePrice)
            {
                double curentPrice = 0;
                
                if (!gameDlc.ContainsKey(game.Key))
                {
                    curentPrice = gamePrice[game.Key] * 0.8;
                    gameNoDlc.Add(game.Key, curentPrice);
                }
                else
                {
                    curentPrice = gamePrice[game.Key] * 0.5;
                    string addDlc = $"{game.Key} - {gameDlc[game.Key]}";
                    gameWhitDlc.Add(addDlc, curentPrice);
                }

            }

            foreach (var item in gameWhitDlc.OrderBy(x => x.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value:f2}");
            }
            foreach (var item in gameNoDlc.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value:f2}");
            }
        }
    }
}
