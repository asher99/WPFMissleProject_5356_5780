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


namespace PL.Converters
{
    public class ReportConverter : IMultiValueConverter
    {
        public GeoCoordinate CurrentLocation { set; get; }
        StringToGeoCoordinate convertAddress { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            CurrentLocation = new GeoCoordinate();
            string address = values[2].ToString();
            convertAddress = new StringToGeoCoordinate(address);
            if (!String.IsNullOrEmpty(address))
            {
                CurrentLocation = convertAddress.startConvert();
            }
            values[2] = CurrentLocation;
            return values.Clone();
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
