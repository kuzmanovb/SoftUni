using System;
using System.Linq;
using System.Collections.Generic;

using PlayersAndMonsters.Repositories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;


namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;
        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public int Count => players.Count;

        public IReadOnlyCollection<IPlayer> Players =>
            this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            foreach (var item in players)
            {
                if (item.Username == player.Username)
                {
                    throw new ArgumentException($"Player {player.Username} already exists!");
                }

            }
            players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return players.FirstOrDefault(p => p.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
           
            return this.players.Remove(player);
        }
    }
}
