using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Device.Location;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BE;
using BLL;  
using GoogleMapsApi;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.PlaceAutocomplete.Request;

namespace PL.Model
{
    public class MissleModel: INotifyPropertyChanged
    {
        private static string googleMapsKey = ConfigurationSettings.AppSettings.Get("GoogleMapsKey");
        private List<string> _locations;
        private BLL_imp currentBll;
        public List<string> locations
        {
            get
            {
                return _locations;
            }
            set
            {
                _locations = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MissleModel()
        {
            currentBll = new BLL_imp();
            locations = new List<string>();
        }

        public Report incomingReport
        {
            get { return incomingReport; }
            set
            {
               // incomingReport = (Report)value;
                currentBll.addReport(value);
            }
        }

        public Hit incomingHit
        {
            get { return incomingHit; }
            set
            {
                incomingHit = value;
                currentBll.addHit(value);
            }
        }

        public bool checkLocations(string leters)
        {
            bool flag = false;
            AddressLocationGoogleMaps(leters);
            flag = true;
            return flag;
        }

        private async void AddressLocationGoogleMaps(string leters)
        {
            List<string> tempResult = new List<string>();
            if (leters == "")
            {
                return;
            }

            else
            {
                try
                {
                    PlaceAutocompleteRequest request = new PlaceAutocompleteRequest();
                    request.ApiKey = googleMapsKey;
                    request.Input = leters;
                    var response = await GoogleMaps.PlaceAutocomplete.QueryAsync(request);
                    foreach (var item in response.Results)
                    {
                        tempResult.Add(item.Description);
                    }
                    locations.Clear();
                    locations = tempResult;
                }
                catch (Exception) { throw; }
            }
        }

        public List<Report> getReportsByDates(DateTime startDate, DateTime endDate)
        {
            if (String.IsNullOrEmpty(startDate.ToString())|| String.IsNullOrEmpty(endDate.ToString())||startDate>endDate)
            {
                return null;
            }
            Task<List<Report>> reports = currentBll.getAllReports();
            List<Report> result = new List<Report>();
            foreach (var item in result)
            {
                if (item.timeOfReport>=startDate&&item.timeOfReport<=endDate)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public Microsoft.Maps.MapControl.WPF.Location Center (List<Report> listOfReport)
        {
            double latitude_Min;
            double latitude_Max;
            double longitude_Min;
            double longitude_Max;
            double latitude_Center;
            double longitude_Center;

            if (listOfReport.Count == 0)
            {
                return null;
            }
            latitude_Min = listOfReport.Min(r => r.Latitude);
            latitude_Max = listOfReport.Max(r => r.Latitude);
            longitude_Min = listOfReport.Min(r => r.Longitude);
            longitude_Max = listOfReport.Max(r => r.Longitude);
            latitude_Center = (latitude_Min + latitude_Max) / 2;
            longitude_Center = (longitude_Min + longitude_Max) / 2;
            return new Microsoft.Maps.MapControl.WPF.Location(latitude_Center, longitude_Center);
        }

        public List<GeoCoordinate> HitByK_Means(List<Report> check_list, int k)
        {
            return currentBll.k_Means(check_list, k);
        }

        public List<Report> allReports()
        {
            Task<List<Report>> reports = currentBll.getAllReports();
            List<Report> result = new List<Report>();
            foreach (var item in result)
            {
                if (item != null)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
