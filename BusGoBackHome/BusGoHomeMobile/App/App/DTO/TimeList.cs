using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App.DTO
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