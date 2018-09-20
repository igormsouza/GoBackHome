using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace W10App.Util
{
    public static class UtilAccessibility
    {
        public static bool VerifyInternetAccess(object activity)
        {
            bool retorno = NetworkInterface.GetIsNetworkAvailable();
            return retorno;
        }
    }
}