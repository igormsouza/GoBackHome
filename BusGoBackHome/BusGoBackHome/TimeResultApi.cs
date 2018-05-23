using System;
using System.Collections.Generic;
using System.Text;

namespace BusGoBackHome
{
    public class TimeResultApi
    {
        public string errorcode { get; set; }
        public string errormessage { get; set; }
        public string numberofresults { get; set; }
        public string stopid { get; set; }
        public string timestamp { get; set; }
        public IList<ItemTimeResultApi> results { get; set; }
    }

    public class ItemTimeResultApi
    {
        public string arrivaldatetime { get; set; }
        public string duetime { get; set; }
        public string departuredatetime { get; set; }
        public string departureduetime { get; set; }
        public string scheduledarrivaldatetime { get; set; }
        public string scheduleddeparturedatetime { get; set; }
        public string destination { get; set; }
        public string destinationlocalized { get; set; }
        public string origin { get; set; }
        public string originlocalized { get; set; }
        public string direction { get; set; }
        public string additionalinformation { get; set; }
        public string lowfloorstatus { get; set; }
        public string route { get; set; }
        public string sourcetimestamp { get; set; }
    }
}
