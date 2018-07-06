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

namespace App
{
    public class TrainFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Tab, container, false);

            var list = view.FindViewById<ListView>(Resource.Id.List);
            list.Adapter = new AdapterList(this.Activity, AplicationCustom.RealTime.timeList.train);

            return view;
        }
    }
}

