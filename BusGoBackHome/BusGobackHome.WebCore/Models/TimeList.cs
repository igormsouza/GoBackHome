using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;

namespace BusGobackHome.WebCore.Models
{
    public class TimeList
    {
        private string addressBus79a = "https://data.dublinked.ie/cgi-bin/rtpi/realtimebusinformation?stopid=6030";
        private string addressBus151 = "https://data.dublinked.ie/cgi-bin/rtpi/realtimebusinformation?stopid=6243";
        private string addressLuas = "https://api.thecosmicfrog.org/cgi-bin/luas-api.php?action=times&station=KYL";

        public void Refresh()
        {
            LastRefresh = DateTime.Now.ToString("HH:mm");

            Calculate79();
            Calculate151();
            Calculate860();
            CalculateLuas();
            CalculateTrain();
        }

        #region Fill lists 

        private void CalculateTrain()
        {
            try
            {
                Train = new List<TimeItem>();
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Train.Add(new TimeItem("error", "-1"));
            }
        }

        private void CalculateLuas()
        {
            try
            {
                Luas = new List<TimeItem>();
                WebClient client = new WebClient();
                string reply = client.DownloadString(addressLuas);
                var objReply = JsonConvert.DeserializeObject<TimeResultApi>(reply);
                Luas.AddRange(objReply.results.Select(o => new TimeItem(o.route, o.departureduetime)).ToList());
            }
            catch (Exception ex)
            {
                Luas.Add(new TimeItem("error", "-1"));
            }
        }

        private void Calculate860()
        {
            try
            {
                Bus860 = new List<TimeItem>();
                var objReply860 = new DirectTimeResult();
                Bus860.AddRange(objReply860.Result.Take(3).Select(o => new TimeItem("860(Direct) ", o.ToString())).ToList());
            }
            catch (Exception ex)
            {
                Bus79a.Add(new TimeItem("error", "-1"));
            }
        }

        private void Calculate151()
        {
            try
            {
                Bus151 = new List<TimeItem>();
                WebClient client = new WebClient();
                string reply = client.DownloadString(addressBus151);
                var objReply = JsonConvert.DeserializeObject<TimeResultApi>(reply);
                Bus151.AddRange(objReply.results.Select(o => new TimeItem(o.route, o.departureduetime)).ToList());
            }
            catch (Exception ex)
            {
                Bus79a.Add(new TimeItem("error", "-1"));
            }
        }

        private void Calculate79()
        {
            try
            {
                Bus79a = new List<TimeItem>();
                WebClient client = new WebClient();
                string reply = client.DownloadString(addressBus79a);
                var objReply = JsonConvert.DeserializeObject<TimeResultApi>(reply);
                Bus79a.AddRange(objReply.results.Select(o => new TimeItem(o.route, o.departureduetime)).ToList());
            }
            catch (Exception ex)
            {
                Bus79a.Add(new TimeItem("error", "-1"));
            }
        }

        #endregion  

        public string LastRefresh { get; set; }

        public List<TimeItem> Bus79a { get; set; }

        public List<TimeItem> Bus151 { get; set; }

        public List<TimeItem> Bus860 { get; set; }

        public List<TimeItem> Luas { get; set; }

        public List<TimeItem> Train { get; set; }
    }
}