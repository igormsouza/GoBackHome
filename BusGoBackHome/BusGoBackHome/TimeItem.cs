﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusGoBackHome
{
    public class TimeItem
    {
        public TimeItem(string name, string departureTime)
        {
            Name = name;
            int aux; int.TryParse(departureTime, out aux);
            DepartureTime = aux;
        }

        public string Name { get; set; }

        public int DepartureTime { get; set; }
    }
}
