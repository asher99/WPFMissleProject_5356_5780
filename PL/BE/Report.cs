using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.ComponentModel.DataAnnotations;
namespace BE
{
    public class Report
    {
        [Key]
        public int EventID { get; set; }
        public DateTime timeOfReport { get; set; }
        public string name { get; set; }
        public GeoCoordinate address { get; set; } // Location of report
        public int numOfBombs { get; set; }
       
        
        /// <summary>
        /// an id report to cluster for k-means algo
        /// </summary>
        public int clusterId { get; set; } 
    }
}
