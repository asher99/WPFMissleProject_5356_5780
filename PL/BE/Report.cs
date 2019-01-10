using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace BE
{
    public class Report
    {
        public DateTime timeOfReport { get; set; }
        public string name { get; set; }
        public GeoCoordinate address { get; set; } // Location
        public int numOfBombs { get; set; }
        public int EventID { get; set; }
    }
}
