using PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE;
using System.Configuration;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Common;

namespace PL.Commands
{
    public class AddReportCommand : ICommand
    {
        private static string googleMapsKey = ConfigurationSettings.AppSettings.Get("GoogleMapsKey");

        private IReportViewModel CurrentVM;
        double longitude;
        double latitude;
        public AddReportCommand(IReportViewModel CurrentVM)
        {
            this.CurrentVM = CurrentVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result = true;
            var values = (object[])parameter;
            if(values != null) { 
                foreach (var item in values)
                {
                    if (item == null)
                    {
                    result = false;
                    }
                }
            }
            return result;
            
        }

        public async void Execute(object parameter)
        {
            var values = (object[])parameter;
            Report report = new Report();
            report.name = values[0].ToString();
            report.timeOfReport = DateTime.Parse( values[1].ToString());
            string address = values[2].ToString();
            
            try
            {
                GeocodingRequest geocodeRequest = new GeocodingRequest();
                geocodeRequest.Address = address;
                geocodeRequest.ApiKey = googleMapsKey;
                GeocodingResponse geocode = await GoogleMaps.Geocode.QueryAsync(geocodeRequest);
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
            }
            report.Latitude = latitude;//coord.Latitude;
            report.Longitude = longitude;//  coord.Longitude;
            report.numOfBombs = int.Parse( values[3].ToString());
            CurrentVM.incomingReport = report;
        }
    }
}

