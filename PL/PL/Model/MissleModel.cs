using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BLL;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.PlaceAutocomplete.Request;

namespace PL.Model
{
    public class MissleModel
    {
        private static string googleMapsKey = ConfigurationSettings.AppSettings.Get("GoogleMapsKey");
        public List<string> locations { set; get; }
        BLL_imp currentBll;

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