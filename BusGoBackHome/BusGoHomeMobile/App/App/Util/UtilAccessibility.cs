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

namespace App.Util
{
    public static class UtilAccessibility
    {
        public static bool VerifyInternetAccess(object activity)
        {
            bool retorno = false;

            if (activity is Activity)
            {
                var auxActivity = activity as Activity;
                retorno = auxActivity.VerifyInternetAccess();
            }

            return retorno;
        }

        public static bool VerifyInternetAccess(this Activity activity)
        {
            Android.Net.ConnectivityManager connectivityManager = (Android.Net.ConnectivityManager)activity.GetSystemService("connectivity");

            Android.Net.NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            bool isOnline = (activeConnection != null) && activeConnection.IsConnected;
            return isOnline;
        }
    }
}