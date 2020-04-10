using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BULLETS_PER_BARREL = 10; 
        private const int TOTAL_BULLET = 100; 
        public Pistol(string name) : base(name, BULLETS_PER_BARREL, TOTAL_BULLET)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel == 0)
            {
                if (TotalBullets >= 10)
                {
                    BulletsPerBarrel = 10;
                    TotalBullets -= 10;
                }
            }

            if (CanFire)
            {
                BulletsPerBarrel--;
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
