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
        private GunRepository guns;
        private readonly List<IPlayer> players;
        private MainPlayer mainPlayer;
        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new List<IPlayer>();
            this.mainPlayer = new MainPlayer();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;
            string massage = null;
            if (type == "Pistol")
            {
                gun = new Pistol(name);
                massage = $"Successfully added {name} of type: {type}";
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
                massage = $"Successfully added {name} of type: {type}";
            }
            else
            {
                massage = "Invalid gun type!";
            }

            if (gun != null)
            {
                guns.Add(gun);
            }

            return massage;
        }

        public string AddGunToPlayer(string name)
        {
            var gun = guns.FirstGun();
            guns.Remove(gun);
            if (gun == null)
            {
                return "There are no guns in the queue!";
            }
            
            if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(gun);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            var player = players.FirstOrDefault(p => p.Name == name);
            
            if (player == null)
            {
                return "Civil player with that name doesn't exists!";
            }

            player.GunRepository.Add(gun);

            return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);

            players.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var fight = new GangNeighbourhood();
            var checkPoints = players.Sum(p=> p.LifePoints);
            var checkCount = players.Count;

            fight.Action(mainPlayer, players);

            if (players.Sum(p=>p.LifePoints) == checkPoints && mainPlayer.LifePoints == 100)
            {
                return "Everything is okay!";
            }
            else
            {
                var deadCivils = checkCount - players.Count;
                
                var sb = new StringBuilder();

                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {deadCivils} players!");
                sb.AppendLine($"Left Civil Players: {players.Count}!");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
