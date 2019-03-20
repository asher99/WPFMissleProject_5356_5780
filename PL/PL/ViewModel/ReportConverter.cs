using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocoding.Microsoft;
using System.Windows.Data;
using Geocoding.MapQuest;
using Geocoding.Microsoft.Json;
using System.Runtime.Serialization.Json;
using System.Device.Location;
using System.Net;
using System.IO;

namespace PL.ViewModel
{
    public class ReportConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            GeoCoordinate address = Geocode((string)values[2]);
            values[2] = address;
            return values.Clone();
        }

        //convert the location to GeoCoordinate
        public static GeoCoordinate Geocode(string address)
        {
            string URL = "http://dev.virtualearth.net/REST/v1/Location?query=" + address +
                "g6V40OMcf2NNJe07qiWD~NhB3DL - oqtYSkUHB5kellQ~Avi_2hYLQtKCC8iFOuBjMx1EQfprwDIzkz782VgpYms7401vYZDrNepSNkxyW_nJ ";
            using (var client = new WebClient())
            {
                string response = client.DownloadString(URL);
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
                using (var es = new MemoryStream(Encoding.Unicode.GetBytes(response)))
                {
                    var mapResponse = (ser.ReadObject(es) as Response);
                    Location location = (Location)mapResponse.ResourceSets.First().Resources.First();
                    return new GeoCoordinate()
                    {
                        Latitude = location.Point.Coordinates[0],
                        Longitude = location.Point.Coordinates[1]
                    };
                }
            }

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
