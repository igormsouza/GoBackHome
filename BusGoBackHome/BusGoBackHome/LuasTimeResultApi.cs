using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusGoBackHome
{
    public class LuasTimeResultApi
    {
        public string message { get; set; }
        public Status status { get; set; }
        public List<Tram> trams { get; set; }
    }

    public class Inbound
    {
        public string message { get; set; }
        public string forecastsEnabled { get; set; }
        public string operatingNormally { get; set; }
    }

    public class Outbound
    {
        public string message { get; set; }
        public string forecastsEnabled { get; set; }
        public string operatingNormally { get; set; }
    }

    public class Status
    {
        public Inbound inbound { get; set; }
        public Outbound outbound { get; set; }
    }

    public class Tram
    {
        public string direction { get; set; }
        public string dueMinutes { get; set; }
        public string destination { get; set; }
    }
}
