using System;
using System.Linq;

using PlayersAndMonsters.IO;
using PlayersAndMonsters.Core.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private ManagerController managerController;
        private Writer writer;
        private Reader reader;
        public Engine()
        {
            this.managerController = new ManagerController();
            this.writer = new Writer();
            this.reader = new Reader();
        }
        public void Run()
        {
            var command = reader.ReadLine().Split().ToArray();

            while (command[0] != "Exit")
            {
                try
                {
                    if (command[0] == "AddPlayer")
                    {
                        var playerType = command[1];
                        var playerName = command[2];
                        var message = managerController.AddPlayer(playerType, playerName);
                        writer.WriteLine(message);
                    }
                    else if (command[0] == "AddCard")
                    {
                        var cardType = command[1];
                        var cardName = command[2];
                        var message = managerController.AddCard(cardType, cardName);
                        writer.WriteLine(message);
                    }
                    else if (command[0] == "AddPlayerCard")
                    {
                        var userName = command[1];
                        var cardName = command[2];
                        var message = managerController.AddPlayerCard(userName, cardName);
                        writer.WriteLine(message);
                    }
                    else if (command[0] == "Fight")
                    {
                        var attackUser = command[1];
                        var enemyUser = command[2];
                        var message = managerController.Fight(attackUser, enemyUser);
                        writer.WriteLine(message);
                    }
                    else if (command[0] == "Report")
                    {
                        writer.WriteLine(managerController.Report());
                    }
                }
                catch (ArgumentException e)
                {
                    writer.WriteLine(e.Message);
                }
                finally
                {
                    command = reader.ReadLine().Split().ToArray();
                }
            }
        }

    }
}
