using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        BLL_imp currentBll;

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
                incomingReport = value;
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
    }
}
