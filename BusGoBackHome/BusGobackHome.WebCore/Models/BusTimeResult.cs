using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DublinBus;
using TrainTimeResult;

namespace BusGobackHome.WebCore.Models
{
    public class BusTimeResult
    {
        public BusTimeResult(GetRealTimeStopDataResponseGetRealTimeStopDataResult objReply1)
        {
            Result = new List<ItemRailTimeResult>();
            this.objReply1 = objReply1;
            var items = objReply1.Any1.Descendants("StopData");

            foreach (var item in items)
            {
                var date = (DateTime)item.Element("MonitoredCall_ExpectedDepartureTime");
                Result.Add(new ItemRailTimeResult() { Name = "79A", Time = date });
            }

            CalculateDueTime();
        }

        private void CalculateDueTime()
        {
            DateTime dateTime = DateTime.UtcNow;
            TimeZoneInfo time = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var currentTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, time);
            
            foreach (var item in Result)
            {
                int dueMin = (int)item.Time.Subtract(currentTime).TotalMinutes;
                item.DueTime = dueMin; 
            }
        }

        private TrainTimeResult.objStationData[] objReplyTrain;
        private GetRealTimeStopDataResponseGetRealTimeStopDataResult objReply1;

        public IList<ItemRailTimeResult> Result { get; set; }
    }

    public class ItemBusTimeResult
    {
        public string Name { get; set; }

        public DateTime Time { get; set; }

        public int DueTime { get; set; }

        public int Delay { get; set; }

    }
}
