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

        public TimeItem(string name, string departureTime, bool useName) : this(name, departureTime)
        {
            UseName = useName;
        }

        public string Name { get; set; }

        public int DepartureTime { get; set; }

        public bool UseName { get; set; }

        public string DepartureTimeStr
        {
            get
            {
                var result = "";

                if (!UseName)
                {
                    switch (DepartureTime)
                    {
                        case 0:
                            result = "due";
                            break;
                        case -1:
                            result = "Service unavailable!";
                            break;
                        default:
                            result = $"{ConvertTime(DepartureTime)}";
                            break;
                    }
                }
                else
                {
                    switch (DepartureTime)
                    {
                        case 0:
                            result = $"due ({Name})";
                            break;
                        case -1:
                            result = "Service unavailable!";
                            break;
                        default:
                            result = $"{ConvertTime(DepartureTime)} ({Name})";
                            break;
                    }
                }

                return result;
            }
        }

        private string ConvertTime(int totalMinutes)
        {
            TimeSpan ts = TimeSpan.FromMinutes(totalMinutes);

            if (ts.Hours > 0)
            {
                return $"{ts.Hours} h : {ts.Minutes} min";
            }
            else
            {
                return $"{ts.Minutes} min";
            }
        }
    }
}
