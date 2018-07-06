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
    public class ReturnDTO<T>
    {
        public ReturnDTO()
        {
            Return = true;
        }

        public T Value { get; set; }

        public bool Return { get; set; }

        public string TitleMessage { get; set; }

        public string ReturnMessage { get; set; }

        public bool DialogMessage { get; set; }


        public void SetarMsgErro(string msg, string title = "Error", bool isDialog = true)
        {
            TitleMessage = title;
            ReturnMessage = msg;
            Return = false;
            DialogMessage = isDialog;
        }

        public void SetMsgSuccess(string msg, string title = "Succed Operation", bool isDialog = false)
        {
            TitleMessage = title;
            ReturnMessage = msg;
            DialogMessage = isDialog;
        }

        public void SetMsgSuccess(bool isDialog = false)
        {
            SetMsgSuccess("Succed Operation");
            DialogMessage = isDialog;
        }
    }
}