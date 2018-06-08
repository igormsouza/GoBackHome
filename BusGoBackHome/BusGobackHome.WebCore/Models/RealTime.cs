using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusGobackHome.WebCore.Models
{
    public class RealTime
    {
        public TimeList TimeList { get; set; }

        public bool Succed { get; set; }

        public string ErrorMsg { get; set; }
    }
}
