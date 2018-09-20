using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using W10App.DTO;
using W10App.Util;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace W10App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            GetTimeAsync();
        }

        private async void GetTimeAsync()
        {
            loading.IsActive = true;
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Wait, 10);

            try
            {
                ReturnDTO<RealTime> realTime = null;

                realTime = await UtilWebService.GetTimeAsync(this, UtilWebService.UrlPath);
                App.RealTime = realTime.Value;

                if (!realTime.Return)
                {
                    UtilMessage.ShowMessage<RealTime>(realTime);
                    pvtTime.Title = realTime.ReturnMessage;
                }
                else
                {
                    pvtTime.Title = "Last refresh: " + realTime.Value.timeList.lastRefresh;
                    CleanAllGrids();

                    FillGrids();
                }
            }
            catch (Exception)
            {
                UtilMessage.PopUpMessage("Error", "Error");
            }
            finally
            {
                loading.IsActive = false;
                Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 10);
            }
        }

        private void FillGrids()
        {
            FillGrid(lv79, App.RealTime.timeList.bus79a);
            FillGrid(lv151, App.RealTime.timeList.bus151);
            FillGrid(lv860, App.RealTime.timeList.bus860);
            FillGrid(lvLuas, App.RealTime.timeList.luas);
            FillGrid(lvTrain, App.RealTime.timeList.train);
        }

        private void FillGrid(ListView listView, List<TimeItem> list)
        {
            foreach (var item in list)
            {
                listView.Items.Add(item.departureTimeStr);
            }
        }

        private void CleanAllGrids()
        {
            lv79.Items.Clear();
            lv151.Items.Clear();
            lv860.Items.Clear();
            lvLuas.Items.Clear();
            lvTrain.Items.Clear();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            GetTimeAsync();
        }
    }
}
