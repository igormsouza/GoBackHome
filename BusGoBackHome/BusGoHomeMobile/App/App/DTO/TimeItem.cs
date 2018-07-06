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
    public class TimeItem
    {
        public string name { get; set; }

        public int departureTime { get; set; }

        public bool useName { get; set; }

        public string departureTimeStr { get; set; }
    }
}