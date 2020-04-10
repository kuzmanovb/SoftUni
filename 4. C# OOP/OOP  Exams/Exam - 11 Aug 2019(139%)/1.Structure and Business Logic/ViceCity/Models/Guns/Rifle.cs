using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BULLETS_PER_BARREL = 50;
        private const int TOTAL_BULLET = 500;
        public Rifle(string name) : base(name, BULLETS_PER_BARREL, TOTAL_BULLET)
        {
        }

        public override int Fire()
        {

            if (this.BulletsPerBarrel == 0)
            {
                if (TotalBullets >= 50)
                {
                    BulletsPerBarrel = 50;
                    TotalBullets -= 50;
                }
            }

            if (CanFire)
            {
                BulletsPerBarrel -= 5;
                return 5;
            }
            else
            {
                return 0;
            }
        }
    }
}
