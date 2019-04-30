using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Device.Location;
using System.Windows.Controls;
using System.Windows.Input;
using PL.Views;
using System.Windows;

namespace PL.Converters
{
    public class ReportConverter : IMultiValueConverter
    {
        public GeoCoordinate CurrentLocation { set; get; }
        StringToGeoCoordinate convertAddress { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ///
            object[] val = new object[5];
            CurrentLocation = new GeoCoordinate();
            string address = values[2].ToString();
            convertAddress = new StringToGeoCoordinate(address);
            if (!String.IsNullOrEmpty(address))
            {
                CurrentLocation = convertAddress.startConvert();
            }
            // 
            val[0] = values[0];
            val[1] = values[1];
            val[2] = CurrentLocation.Latitude;
            val[3] = CurrentLocation.Longitude;
            val[4] = values[3];
            ///
            //DateTime tempDateTime = new DateTime();
            //tempDateTime = DateTime.Parse(values[1].ToString());
            //tempDateTime.AddMonths(((DateTime)values[1]).Month);
            //tempDateTime.AddYears(((DateTime)values[1]).Year);
            //tempDateTime.AddHours(((TimeSpan)values[4]).Hours);
            //tempDateTime.AddMinutes(((TimeSpan)values[4]).Minutes);
            //values[1] = tempDateTime;

            return val;//values.Clone();
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
