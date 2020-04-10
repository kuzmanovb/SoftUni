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

            var currentCivil = civilPlayers.FirstOrDefault(c => c.IsAlive);

            var currentMainGun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire);

            while (currentMainGun != null)
            {

                var damage = currentMainGun.Fire();
                currentCivil.TakeLifePoints(damage);

                if (!currentMainGun.CanFire)
                {
                    mainPlayer.GunRepository.Remove(currentMainGun);
                    currentMainGun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire);
                }
                if (!currentCivil.IsAlive)
                {
                    civilPlayers.Remove(currentCivil);
                    currentCivil = civilPlayers.FirstOrDefault(c => c.IsAlive);
                }

                if (currentMainGun == null || currentCivil == null)
                {
                    break;
                }
            }



            if (civilPlayers.Count == 0)
            {
                return;
            }
            var currentCivilGun = civilPlayers.FirstOrDefault(c => c.GunRepository.Models.Count > 0)?.GunRepository.Models.FirstOrDefault(g => g.CanFire);

            while (mainPlayer.IsAlive && currentCivilGun != null)
            {

                var damage = currentCivilGun.Fire();
                mainPlayer.TakeLifePoints(damage);

                if (!currentCivilGun.CanFire)
                {
                    currentCivil.GunRepository.Remove(currentCivilGun);
                    currentCivilGun = civilPlayers.FirstOrDefault(c => c.GunRepository.Models.Count > 0)?.GunRepository.Models.FirstOrDefault(g => g.CanFire);
                }

                if (currentCivilGun == null)
                {
                    break;
                }
            }

        }
    }
}
