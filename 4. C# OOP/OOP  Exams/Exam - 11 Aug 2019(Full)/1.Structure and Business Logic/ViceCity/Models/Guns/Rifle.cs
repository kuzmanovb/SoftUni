using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        //Has 50 bullets per barrel and 500 total bullets.
        public Rifle(string name) : base(name, 50 , 500)
        {
        }

        public override int Fire()
        {
            //The rifle can shoot with 5 bullets.
            if (BulletsPerBarrel == 0 && TotalBullets >= 50)
            {
                BulletsPerBarrel = 50;
                TotalBullets -= 50;
            }

            BulletsPerBarrel-= 5;

            return 5;
        }
    }
}
