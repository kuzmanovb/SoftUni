using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            
            while (mainPlayer.GunRepository.Models.Any(g => g.CanFire))
            {
                //TODO
                if (!civilPlayers.Any(c => c.IsAlive))
                {
                    return;
                }
                var gun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire);

                var civil = civilPlayers.FirstOrDefault(c => c.IsAlive);

                var damage = gun.Fire();
                civil.TakeLifePoints(damage);

                if (!civil.IsAlive)
                {
                    civilPlayers.Remove(civil);
                }
            }

            while (civilPlayers.Any(c => c.GunRepository.Models.Any(g => g.CanFire)))
            {

                IGun civilGun = null;

                foreach (var item in civilPlayers)
                {
                    civilGun = item.GunRepository.Models.FirstOrDefault(g => g.CanFire);

                    if (civilGun != null)
                    {
                        break;
                    }
                   
                }


                var damage = civilGun.Fire();
                mainPlayer.TakeLifePoints(damage);

                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }
        }
    }
}
