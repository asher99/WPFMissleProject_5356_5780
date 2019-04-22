using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Device.Location;
using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class Hit
    {
        [Key]
        public int EventID { get; set; }
        public DateTime timeOfHit { set; get; }
        public GeoCoordinate address { set; get; } // Location
        //public Image locationImage { set; get; }
        
    }
}
