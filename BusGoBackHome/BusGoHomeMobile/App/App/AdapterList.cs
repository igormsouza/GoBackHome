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

namespace App
{
    public class AdapterList : BaseAdapter
    {
        private Activity context;
        private List<TimeItem> listAux;

        public AdapterList(Activity context, List<TimeItem> listAux)
        {
            this.context = context;
            this.listAux = listAux;
        }

        public override int Count
        {
            get
            {
                return listAux.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view;
            var item = listAux[position];

            view = context.LayoutInflater.Inflate(Resource.Layout.AdapterItem, parent, false);
            var txtTime = view.FindViewById<TextView>(Resource.Id.txtTime);
            txtTime.Text = item.departureTimeStr;

            return view;
        }
    }
}