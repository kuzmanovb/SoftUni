﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface ICitizens : IId, IBirthdate
    {
        string Name { get; }
        string Age { get; }


    }
}
