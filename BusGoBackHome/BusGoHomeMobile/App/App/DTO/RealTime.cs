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
    public class RealTime
    {
        public TimeList timeList { get; set; }

        public bool succeed { get; set; }

        public string errorMsg { get; set; }
    }
}