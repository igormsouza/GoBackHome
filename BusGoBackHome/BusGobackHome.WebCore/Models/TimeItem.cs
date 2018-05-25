using System;
using System.Collections.Generic;
using System.Text;

namespace BusGobackHome.WebCore.Models
{
    public class TimeItem
    {
        public TimeItem(string name, string departureTime)
        {
            Name = name;
            int aux; int.TryParse(departureTime, out aux);
            DepartureTime = aux;
        }

        public string Name { get; set; }

        public int DepartureTime { get; set; }

        public string DepartureTimeStr
        {
            get
            {
                var result = "";

                switch (DepartureTime)
                {
                    case 0:
                        result = "due";
                        break;
                    case -1:
                        result = "Service unavailable!";
                        break;
                    default:
                        result = $"{DepartureTime} min";
                        break;
                }

                return result;
            }
        }
    }
}
