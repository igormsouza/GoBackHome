using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using W10App.DTO;
using Windows.UI.Xaml.Controls;

namespace W10App.Util
{
    public static class UtilMessage
    {
        public static void ShowMessage<T>(ReturnDTO<T> result)
        {
            if (!string.IsNullOrWhiteSpace(result.ReturnMessage))
            {
                PopUpMessage(result.TitleMessage, result.ReturnMessage);
            }
        }

        public static void PopUpMessage(string title, string mensage)
        {
            PopUpMessage(title, mensage, "OK", null);
        }

        public static async void PopUpMessage(string title, string mensage, string textButton, Action actionButton)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = title,
                Content = mensage,
                SecondaryButtonText = textButton
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();

            if (result == ContentDialogResult.Secondary && actionButton != null)
            {
                actionButton();
            }
        }
    }
}