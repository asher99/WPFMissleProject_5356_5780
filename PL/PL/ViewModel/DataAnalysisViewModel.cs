using BE;
using Microsoft.Maps.MapControl.WPF;
using PL.Model;
using System;
using MColor = System.Windows.Media.Color;
using DColor = System.Drawing.Color;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Device.Location;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PL.ViewModel
{
    class DataAnalysisViewModel : INotifyPropertyChanged
    {
        public MissleModel currentModel { set; get; }
        public ObservableCollection<Report> Reports { get; set; }
        public ObservableCollection<Hit> Hits { get; set; }
        public ObservableCollection<Pushpin> pushpins { get; set; }
        public ObservableCollection<GeoCoordinate> K_means_collection { get; set; }
        private double _ZoomLevel;
        public double ZoomLevel
        {
            set
            {
                _ZoomLevel = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ZoomLevel"));
            }
            get { return _ZoomLevel; }
        }
        public DateTime start { set; get; }
        public DateTime end { set; get; }
        public string eventNum { set; get; } = "Numbers only";
        public string K_Means { set; get; } = "Numbers only";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DataAnalysisViewModel()
        {
            ZoomLevel = 7.2;
            CenterLocation = new Location(31.5, 35);
            K_means_collection = new ObservableCollection<GeoCoordinate>();
            Hits = new ObservableCollection<Hit>();
            Reports = new ObservableCollection<Report>();
            currentModel = new MissleModel();
            CenterLocation = new Location();
            pushpins = new ObservableCollection<Pushpin>();
            pushpins.CollectionChanged += (sender, args) =>
            {
                OnPropertyChanged("pushpins");
            };
        }

        public async void allCurrentReport()
        {
            pushpins.Clear();
            Reports.Clear();
            List<Report> result = new List<Report>();
            if (end != null)
            {
                var allreport = await currentModel.getReportsByDates(start, end);
                foreach (var item in allreport)
                {
                    updateReportsAndPushPins(item);
                    result.Add(item);
                }
                CenterLocation = currentModel.Center(result);
            }
            else
            {
                DateTime tempend = start;
                tempend.AddMinutes(10 * Convert.ToInt32(eventNum));
                var allreport = await currentModel.getReportsByDates(start, tempend);
                foreach (var item in allreport)
                {
                    updateReportsAndPushPins(item);
                    result.Add(item);
                }
                CenterLocation = currentModel.Center(result);
            }
        }

        public void updateReportsAndPushPins(Report item)
        {
            Pushpin pin = new Pushpin();
            Location tempLocation = new Location();
            Reports.Add(item);
            tempLocation.Latitude = item.Latitude;
            tempLocation.Longitude = item.Longitude;
            pin.Location = tempLocation;
            pin.Background = new SolidColorBrush(ToMediaColor(System.Drawing.Color.FromName("Blue")));
            pushpins.Add(pin);
        }

        public void HitByK_Means()
        {
            List<Report> result = new List<Report>();
            foreach (var item in Reports)
            {
                result.Add(item);
            }
            List<GeoCoordinate> byKMeans = currentModel.HitByK_Means(result, Convert.ToInt32(K_Means));
            foreach (var item in byKMeans)
            {
                updateKMeansCollectionAndPushPins(item);
            }
        }

        public void updateKMeansCollectionAndPushPins(GeoCoordinate item)
        {
            Pushpin pin = new Pushpin();
            Location tempLocation = new Location();
            K_means_collection.Add(item);
            tempLocation.Latitude = item.Latitude;
            tempLocation.Longitude = item.Longitude;
            pin.Location = tempLocation;
            pin.Background = new SolidColorBrush(ToMediaColor(System.Drawing.Color.FromName("Green")));
            pushpins.Add(pin);
        }

        public async void allCurrentHits()
        {
            Hits.Clear();
            if (end != null)
            {
                var allhits = await currentModel.getHitsByDates(start, end);
                foreach (var item in allhits)
                {
                    updateHitsAndPushPins(item);
                }
            }
            else
            {
                DateTime tempend = start;
                tempend.AddMinutes(10 * Convert.ToInt32(eventNum));
                var allhits = await currentModel.getHitsByDates(start, end);
                foreach (var item in allhits)
                {
                    updateHitsAndPushPins(item);
                }
            }
        }

        public void updateHitsAndPushPins(Hit item)
        {
            Pushpin pin = new Pushpin();
            Location tempLocation = new Location();
            Hits.Add(item);
            tempLocation.Latitude = item.Latitude;
            tempLocation.Longitude = item.Longitude;
            pin.Location = tempLocation;
            pin.Background = new SolidColorBrush(ToMediaColor(System.Drawing.Color.FromName("Red")));
            pushpins.Add(pin);
        }

        public MColor ToMediaColor(DColor color)
        {
            return MColor.FromArgb(color.A, color.R, color.G, color.B);
        }

        /*public List<Report> allCurrentReport
        {
            set { }
            get
            {
                if (end != null)
                {
                    var allreport =  currentModel.getReportsByDates(start, end);
                }
                else
                {
                    DateTime tempend = start;
                    tempend.AddMinutes (10 * Convert.ToInt32(eventNum));
                    allCurrentReport =  currentModel.getReportsByDates(start, tempend);
                }
                return allCurrentReport;
            }
        }*/

        private Location _centerlocation;
        public Location CenterLocation
        {
            set
            {
                _centerlocation = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CenterLocation"));
            }
            get { return _centerlocation; }

        }
    }
}
