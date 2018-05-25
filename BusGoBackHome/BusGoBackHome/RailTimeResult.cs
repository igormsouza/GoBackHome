using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusGoBackHome
{
    public class RailTimeResult
    {
        public RailTimeResult(TrainTimeResult.objStationData[] objReplyTrain)
        {
            Result = new List<ItemRailTimeResult>();
            this.objReplyTrain = objReplyTrain;
            CalculateDueTime();
        }

        private void CalculateDueTime()
        {
            //16:03
            //var aux = objReplyTrain.ToList().Where(o => o.Scharrival.Contains(":")).Select(o => ConvertTimeStringToDatetime(o.Scharrival) >= DateTime.Now).ToList();
            var auxConvert = objReplyTrain.Where(o => o.Scharrival.Contains(":")).Select(o => new ItemRailTimeResult() { Time = ConvertTimeStringToDatetime(o.Scharrival), Name = "Train to " + o.Direction } );
            var aux = auxConvert.Where(o => o.Time > DateTime.Now).OrderBy(o => o.Time).ToList();
            foreach (var item in aux)
            {
                int dueMin = (int)item.Time.Subtract(DateTime.Now).TotalMinutes;
                item.DueTime = dueMin;

                Result.Add(item);
            }
        }

        private DateTime ConvertTimeStringToDatetime(string arrivalTime)
        {
            var aux = arrivalTime.Split(':');
            int hour; int.TryParse(aux[0], out hour);
            int minutes; int.TryParse(aux[1], out minutes);
            var result = DateTime.Today.AddHours(hour).AddMinutes(minutes);
            return result;
        }

        private TrainTimeResult.objStationData[] objReplyTrain;

        public IList<ItemRailTimeResult> Result { get; set; }
    }

    public class ItemRailTimeResult
    {
        public string Name { get; set; }

        public DateTime Time { get; set; }

        public int DueTime { get; set; }
    }
}
