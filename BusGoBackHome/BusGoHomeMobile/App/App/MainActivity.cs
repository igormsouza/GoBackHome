using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using App.Util;
using App.DTO;
using Android.Views;
using System;

namespace App
{
    [Activity(Label = "Park West Commute", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            GetTimeAsync();
        }
        
        private async void GetTimeAsync()
        {
            var loading = ProgressDialog.Show(this, "Park West Commute", "Loading...", true);

            try
            {
                ReturnDTO<RealTime> realTime = null;

                realTime = await UtilWebService.GetTimeAsync(this, UtilWebService.UrlPath);
                AplicationCustom.RealTime = realTime.Value;

                var lastRefresh = FindViewById<TextView>(Resource.Id.txtLastRefresh);

                if (!realTime.Return)
                {
                    UtilMessage.ShowMessage<RealTime>(this, realTime);
                    lastRefresh.Text = realTime.ReturnMessage;
                }
                else
                {
                    lastRefresh.Text = "Last refresh: " + realTime.Value.timeList.lastRefresh;
                    this.ActionBar.RemoveAllTabs();
                    this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

                    AddTab("79A", new Bus79Fragment());
                    AddTab("151", new Bus151Fragment());
                    AddTab("860", new Bus860Fragment());
                    AddTab("Luas", new LuasFragment());
                    AddTab("Train", new TrainFragment());
                }
            }
            catch (Exception)
            {
                UtilMessage.PopUpMessage(this, "Error", "Error");
            }
            finally
            {
                loading.Hide();
            }           
        }

        void AddTab(string tabText, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);

            // must set event handler for replacing tabs tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Replace(Resource.Id.fragmentContainer, fragment);
            };

            this.ActionBar.AddTab(tab);
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            menu.Clear();
            MenuInflater.Inflate(Resource.Menu.menu, menu);

            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.mnRefresh:
                    GetTimeAsync();
                    return true;
                case Resource.Id.mnExit:
                    var builder = new AlertDialog.Builder(this);
                    builder.SetMessage("Are you sure that you want exit the application?");
                    builder.SetPositiveButton("Yes", (s, e) => { Java.Lang.JavaSystem.Exit(0); });
                    builder.SetNegativeButton("No", (s, e) => { });
                    builder.Create().Show();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

