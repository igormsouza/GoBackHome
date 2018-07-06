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
using App.DTO;
using App.Util;

namespace App
{
    [Application]
    public class AplicationCustom : Application
    {
        public static RealTime RealTime { get; set; }

        public AplicationCustom(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
            RealTime = new RealTime();
        }

    }
}