using GoogleMapsApi;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Converters
{
    class StringToGeoCoordinate
    {
        private static string googleMapsKey = "AIzaSyC2z5jSiWtVK - R8rgRk87ZcCBMvmGIusWk";
        string address;
        bool flag = false;
        public GeoCoordinate CurrentLocation { set; get; }

        public StringToGeoCoordinate(string address)
        {
            this.address = address;
        }

        public GeoCoordinate startConvert()
        {
            CurrentLocation = new GeoCoordinate();
            stringToGeoCoordinate(address);
            //while (!flag) ;
            return CurrentLocation;
        }

        private async void stringToGeoCoordinate(string address)
        {
            try
            {
                GeocodingRequest geocodeRequest = new GeocodingRequest();
                geocodeRequest.Address = address;
                geocodeRequest.ApiKey = googleMapsKey;
                GeocodingResponse geocode = await GoogleMaps.Geocode.QueryAsync(geocodeRequest);
                if (geocode.Status == Status.OK)
                {
                    IEnumerator<Result> iter = geocode.Results.GetEnumerator();
                    iter.MoveNext();
                    Location tempLocation = iter.Current.Geometry.Location;
                    CurrentLocation.Latitude = tempLocation.Latitude;
                    CurrentLocation.Longitude = tempLocation.Longitude;
                    flag = true;
                }
            }
            catch (Exception) { }
        }

    }
}
