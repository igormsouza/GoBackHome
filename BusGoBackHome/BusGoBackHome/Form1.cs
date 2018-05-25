using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BusGoBackHome
{
    public partial class Form1 : Form
    {
        private string bus79a = "https://data.dublinked.ie/cgi-bin/rtpi/realtimebusinformation?stopid=6030";
        private string bus151 = "https://data.dublinked.ie/cgi-bin/rtpi/realtimebusinformation?stopid=6243";
        private string luas = "https://api.thecosmicfrog.org/cgi-bin/luas-api.php?action=times&station=KYL";

        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        public Form1()
        {
            InitializeComponent();
            //RefreshScreen();

            this.ClientSize = new System.Drawing.Size(520, 450);
            this.Name = "Program";

            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Show", FormShow);
            trayMenu.MenuItems.Add("Exit", ForExit);
            trayIcon = new NotifyIcon();
            trayIcon.Text = "Bus Go Back Home";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
            TopMost = true;
            Resize += new EventHandler(Form1_Resize);
        }

        private void ForExit(object sender, EventArgs e)
        {
            this.Close();
        }

        void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                Hide();
                trayIcon.Visible = true;
            }
        }

        void FormShow(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            ShowInTaskbar = true;
            Show();
            Focus();
            trayIcon.Visible = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            RefreshScreen();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshScreen();
        }

        private void RefreshScreen()
        {
            Cursor.Current = Cursors.WaitCursor;
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            grid.DataSource = BindGrid();
            Cursor.Current = Cursors.Default;
        }

        private IList<TimeItem> BindGrid()
        {
            List<TimeItem> list = new List<TimeItem>();

            try
            {
                WebClient client = new WebClient();
                string reply79a = client.DownloadString(bus79a);
                var objReply79a = JsonConvert.DeserializeObject<TimeResultApi>(reply79a);

                string reply151 = client.DownloadString(bus151);
                var objReply151 = JsonConvert.DeserializeObject<TimeResultApi>(reply151);

                string replyLuas = client.DownloadString(luas);
                var objReplyLuas = JsonConvert.DeserializeObject<LuasTimeResultApi>(replyLuas);

                var objReply860 = new DirectTimeResult();

                var replyTrain = new TrainTimeResult.RealtimeSoapClient();
                var objReplyTrain = replyTrain.getStationDataByNameXML1("Cherry Orchard");
                var objConvertedTrain = new RailTimeResult(objReplyTrain);

                list.AddRange(objReply79a.results.Take(3).Select(o => new TimeItem(o.route, o.departureduetime)).ToList());
                list.AddRange(objReply151.results.Take(3).Select(o => new TimeItem(o.route, o.departureduetime)).ToList());
                list.AddRange(objReplyLuas.trams.Take(3).Select(o => new TimeItem("Luas " + o.destination, o.dueMinutes)).ToList());
                list.AddRange(objReply860.Result.Take(3).Select(o => new TimeItem("860(Direct) ", o.ToString())).ToList());
                list.AddRange(objConvertedTrain.Result.Take(3).Select(o => new TimeItem(o.Name , o.DueTime.ToString())).ToList());

                list = list.OrderBy(o => o.DepartureTime).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service unavailable!");
            }

            return list;
        }
    }
}
