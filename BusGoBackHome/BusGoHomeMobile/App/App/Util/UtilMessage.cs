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

namespace App.Util
{
    public static class UtilMessage
    {
        public static void ShowMessage<T>(object activity, ReturnDTO<T> result)
        {
            if (!string.IsNullOrWhiteSpace(result.ReturnMessage))
            {
                if (result.DialogMessage)
                {
                    PopUpMessage(activity, result.TitleMessage, result.ReturnMessage);
                }
                else
                {
                    if (activity is Activity)
                    {
                        var auxActivity = activity as Activity;
                        Toast.MakeText(auxActivity, result.ReturnMessage, ToastLength.Long).Show();
                    }
                }
            }
        }

        public static void PopUpMessage(object tela, string titulo, string mensagem)
        {
            PopUpMessage(tela, titulo, mensagem, "OK", null);
        }

        public static void PopUpMessage(object tela, string titulo, string mensagem, string textoBotao, Action acaoBotao)
        {
            if (tela is Activity)
            {
                var activity = tela as Activity;
                if (!string.IsNullOrWhiteSpace(mensagem))
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(activity);
                    alert = new AlertDialog.Builder(activity);
                    alert.SetTitle(titulo);
                    alert.SetMessage(mensagem);
                    alert.SetCancelable(true);
                    alert.SetPositiveButton(textoBotao, delegate
                    {
                        if (acaoBotao != null)
                        {
                            acaoBotao.Invoke();
                        }
                    });
                    alert.Show();
                }
            }
        }
    }
}