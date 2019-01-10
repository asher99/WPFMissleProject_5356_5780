using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Device.Location;

namespace BE
{
    public class Hit
    {
        public DateTime timeOfHit { set; get; }
        public GeoCoordinate address { set; get; } // Location
        public Image locationImage { set; get; }
        public int EventID { get; set; }
    }
}
