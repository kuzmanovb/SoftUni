using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        //Has 100 initial life points and the main player has only one name "Tommy Vercetti". 

        public MainPlayer() : base("Tommy Vercetti", 100)
        {
        }
    }
}
