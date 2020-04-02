using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            if (type == "Advanced")
            {
                return new Advanced(new CardRepository(), username);
            }
            else if (type == "Beginner")
            {
                return new Beginner(new CardRepository(), username);
            }
            else
            {
                return null;
            }
        }
    }
}
