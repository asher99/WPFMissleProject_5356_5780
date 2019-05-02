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
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using GoogleMapsApi;
using System.Configuration;
using GoogleMapsApi.Entities.Common;
using System.Threading;
using System.Windows.Threading;

namespace PL.Converters
{
    public class ReportConverter : IMultiValueConverter
    {
        // public GeoCoordinate CurrentLocation { set; get; }
        // StringToGeoCoordinate convertAddress { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ///
            /*object[] val = new object[5];
            string address = values[2].ToString();
            StringToGeoCoordinate(address);
           
            new Thread(() =>
            {
                double longitude;
                double latitude;
                try
                {
                    GeocodingRequest geocodeRequest = new GeocodingRequest();
                    geocodeRequest.Address = address;
                    geocodeRequest.ApiKey = googleMapsKey;
                    GeocodingResponse geocode =  GoogleMaps.Geocode.Query(geocodeRequest);
                    //GeocodingResponse geocode = GoogleMaps.Geocode.Query(geocodeRequest);
                    if (geocode.Status == Status.OK)
                    {
                        IEnumerator<Result> iter = geocode.Results.GetEnumerator();
                        iter.MoveNext();
                        Location tempLocation = iter.Current.Geometry.Location;
                        latitude = tempLocation.Latitude;
                        longitude = tempLocation.Longitude;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

                Dispatcher.Invoke(new Action(() =>
                {
                    val[0] = values[0];
                    val[1] = values[1];
                    val[2] = latitude;
                    val[3] = longitude;
                    val[4] = values[3];

                }));
            }).Start();            //if (!String.IsNullOrEmpty(address))
            //{
            // CurrentLocation = convertAddress.startConvert();
            //}
            // 
            
            ///
            //DateTime tempDateTime = new DateTime();
            //tempDateTime = DateTime.Parse(values[1].ToString());
            //tempDateTime.AddMonths(((DateTime)values[1]).Month);
            //tempDateTime.AddYears(((DateTime)values[1]).Year);
            //tempDateTime.AddHours(((TimeSpan)values[4]).Hours);
            //tempDateTime.AddMinutes(((TimeSpan)values[4]).Minutes);
            //values[1] = tempDateTime;*/

            return values.Clone();
        }

        public async void StringToGeoCoordinate(string address)
        {
            
            try
            {
                
            }
            catch (Exception) { }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
