using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private GunRepository repo;
        private ICollection<IPlayer> players;
        private MainPlayer mainPlayer;
        public Controller()
        {
            this.repo = new GunRepository();
            this.players = new List<IPlayer>();
            this.mainPlayer = new MainPlayer();

        }

        public string AddGun(string type, string name)
        {
            IGun currentGun = null;
            string massage = null;
            if (type == "Pistol")
            {
                currentGun = new Pistol(name);
                massage = $"Successfully added {name} of type: {type}";
            }
            else if (type == "Rifle")
            {
                currentGun = new Rifle(name);
                massage = $"Successfully added {name} of type: {type}";
            }
            else
            {
                massage = "Invalid gun type!";
            }
            if (currentGun != null)
            {
                repo.Add(currentGun);
            }

            return massage;
        }

        public string AddGunToPlayer(string name)
        {
            string massage = null;
            if (repo.Models.Count == 0)
            {
                massage = "There are no guns in the queue!";
            }
            else if (name == "Vercetti")
            {
                var currentGun = repo.Models.First();
                repo.Remove(currentGun);

                mainPlayer.GunRepository.Add(currentGun);

                massage = $"Successfully added {currentGun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (null == players.FirstOrDefault(p => p.Name == name))
            {
                massage = "Civil player with that name doesn't exists!";
            }
            else
            {
                var currentPlayer = players.FirstOrDefault(p => p.Name == name);
                var currentGun = repo.Models.First();

                currentPlayer.GunRepository.Add(currentGun);
                repo.Remove(currentGun);

                massage = $"Successfully added {currentGun.Name} to the Civil Player: {currentPlayer.Name}";
            }

            return massage;
        }

        public string AddPlayer(string name)
        {
            var currentPlayer = new CivilPlayer(name);
            players.Add(currentPlayer);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var fight = new GangNeighbourhood();
            var pointPlayers = players.Sum(p => p.LifePoints);
            var countPlayers = players.Count;
            var pointsMainPlayer = mainPlayer.LifePoints;
            fight.Action(mainPlayer, players);

            var pointPlayersAftarAtac = players.Sum(p => p.LifePoints);
            var countPlayersAftarAtac = players.Count;
            var pointsMainPlayerAftarAtac = mainPlayer.LifePoints;

            var deadPlayers = countPlayers - countPlayersAftarAtac;

            var sb = new StringBuilder();

            if (pointPlayers != pointPlayersAftarAtac || pointsMainPlayer != pointsMainPlayerAftarAtac)
            {
                sb.AppendLine("A fight happened:")
                    .AppendLine($"Tommy live points: {pointsMainPlayerAftarAtac}!")
                    .AppendLine($"Tommy has killed: {deadPlayers} players!")
                    .AppendLine($"Left Civil Players: {countPlayersAftarAtac}!");
            }
            else
            {
                sb.AppendLine("Everything is okay!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
