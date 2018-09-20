using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W10App.DTO
{
    public class RealTime
    {
        public TimeList timeList { get; set; }

        public bool succeed { get; set; }

        public string errorMsg { get; set; }
    }
}