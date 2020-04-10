using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        //Has 50 initial life points.
        public CivilPlayer(string name)
            : base(name, 50)
        {
        }
    }
}
