using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        //Has 10 bullets per barrel and 100 total bullets.
        public Pistol(string name) 
            : base(name, 10, 100)
        {
        }

        public override int Fire()
        {
            //The pistol shoots only one bullet.

            if (BulletsPerBarrel == 0 && TotalBullets>= 10)
            {
                BulletsPerBarrel = 10;
                TotalBullets -= 10;
            }

            BulletsPerBarrel--;

            return 1;
        }
    }
}
