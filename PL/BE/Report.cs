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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public GeoCoordinate address { get; set; } // Location of report
        public int numOfBombs { get; set; }
       
        
        /// <summary>
        /// an id report to cluster for k-means algo
        /// </summary>
        public int clusterId { get; set; } 

       public  Report(int id, DateTime date, string _name, int falls)
        {
            EventID = id;
            timeOfReport = date;
            name = _name;
            Latitude = 3.45;
            Longitude = 1.23;
            numOfBombs = falls;
        }

        public Report(){ }

        public GeoCoordinate GetCoordinate()
        {
            return new GeoCoordinate(Latitude, Longitude);
        }
    }
}
