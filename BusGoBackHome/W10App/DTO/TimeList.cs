using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace W10App.DTO
{
    public class TimeList
    {
        public string lastRefresh { get; set; }

        public List<TimeItem> bus79a { get; set; }

        public List<TimeItem> bus151 { get; set; }

        public List<TimeItem> bus860 { get; set; }

        public List<TimeItem> luas { get; set; }

        public List<TimeItem> train { get; set; }
    }
}