using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        private const int LIFE_POINTS = 100;
        public CivilPlayer(string name) : base(name, LIFE_POINTS)
        {
        }
    }
}
