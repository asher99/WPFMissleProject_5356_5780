using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using BE;

namespace BLL
{
    class BLL_imp : I_Bll
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="report_List"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public List<GeoCoordinate> k_Means(List<Report> report_List, int k)
        {
            //Initates list of central points       
            List<GeoCoordinate> ci_List = new List<GeoCoordinate>();
            double latitude_Min;
            double latitude_Max;
            double longitude_Min;
            double longitude_Max;

            if (report_List.Count == 0)
            {
                return null;
            }
            //We will generate k central point by findingrandom points in the surronded area
            latitude_Min = report_List.Min(r => r.address.Latitude);
            latitude_Max = report_List.Max(r => r.address.Latitude);
            longitude_Min = report_List.Min(r => r.address.Longitude);
            longitude_Max = report_List.Max(r => r.address.Longitude);

            for (int i = 0; i < k; i++)
            {
                Random r = new Random();
                double latitude = latitude_Min + r.NextDouble() * (latitude_Max - latitude_Min);
                double longitude = longitude_Min + r.NextDouble() * (longitude_Max - longitude_Min);
                GeoCoordinate c = new GeoCoordinate(latitude, longitude);
                ci_List.Add(c);
            }

            bool is_Changed;
            do
            {
                is_Changed = false;
                //For each report we will find its closest center point
                for (int i = 0; i < report_List.Count; i++)
                {
                    double min = report_List[i].address.GetDistanceTo(ci_List[0]);
                    report_List[i].clusterId = 0;

                    for (int j = 1; j < ci_List.Count; j++)
                    {
                        double temp = report_List[i].address.GetDistanceTo(ci_List[j]);
                        if (temp < min)
                        {
                            min = temp;
                            is_Changed = true;
                            report_List[i].clusterId = j;
                        }
                    }

                }

                //finds new center points of each cluster
                report_List.OrderBy(c => c.clusterId);
                int id = 0;
                double c_LongitudeSum = 0;
                double c_LatitudeSum = 0;
                int counter = 0;
                for (int i = 0; i < report_List.Count; i++)
                {
                    if (report_List[i].clusterId==id)
                    {
                        c_LatitudeSum += report_List[i].address.Latitude;
                        c_LongitudeSum += report_List[i].address.Longitude;
                        counter++;
                    }
                    if (report_List[i].clusterId != id)
                    {
                        ci_List[id].Latitude = c_LatitudeSum / counter;
                        ci_List[id].Longitude = c_LongitudeSum / counter;
                        counter = 0;
                        c_LongitudeSum = 0;
                        c_LatitudeSum = 0;
                        i--;
                        id++;
                    }
                }

            } while (is_Changed);

            return ci_List;
        }
    }
}
