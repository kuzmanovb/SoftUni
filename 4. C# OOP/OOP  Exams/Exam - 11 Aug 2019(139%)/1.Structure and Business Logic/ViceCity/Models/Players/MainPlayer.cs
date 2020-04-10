﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const string NAME = "Tommy Vercetti";
        private const int LIFE_POINTS = 100;
        public MainPlayer() : base(NAME, LIFE_POINTS)
        {
        }
    }
}
