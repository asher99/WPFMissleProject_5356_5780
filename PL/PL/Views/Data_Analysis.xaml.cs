using Microsoft.Maps.MapControl.WPF;
using System.Drawing;
using MColor = System.Windows.Media.Color;
using DColor = System.Drawing.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PL.ViewModel;

namespace PL.Views
{
    /// <summary>
    /// Interaction logic for Data_Analysis.xaml
    /// </summary>
    public partial class Data_Analysis : Window
    {
        DataAnalysisViewModel dataAnalysisViewModel { set; get; }
        public Data_Analysis()
        {
            dataAnalysisViewModel = new DataAnalysisViewModel();
            this.DataContext = dataAnalysisViewModel;
            InitializeComponent();
        }

        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            myMap.Children.Clear();
            Location center = new Microsoft.Maps.MapControl.WPF.Location(dataAnalysisViewModel.CenterLocation);
            myMap.SetView(center, 10.0);
            Pushpin pin = new Pushpin();
            Location tempLocation = new Location();
            foreach (var item in dataAnalysisViewModel.allCurrentReport)
            {
                tempLocation.Latitude = item.address.Latitude;
                tempLocation.Longitude = item.address.Longitude;
                pin.Location = tempLocation;
                pin.Background = new SolidColorBrush(ToMediaColor(System.Drawing.Color.FromName("Red")));
                myMap.Children.Add(pin);
            }

        }

        public MColor ToMediaColor(DColor color)
        {
            return MColor.FromArgb(color.A, color.R, color.G, color.B);
        }

        private void MapCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            myMap.Mode = new AerialMode();
        }

        private void MapCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            myMap.Mode = new RoadMode();
        }

        private void DisplayByEvents_Checked(object sender, RoutedEventArgs e)
        {
            startTime.Text = null;
            startTime.IsEnabled = false;
            endTime.Text = null;
            endTime.IsEnabled = false;
            eventStartTime.IsEnabled = true;
            eventNum.IsEnabled = true;
        }       

        private void DisplayByEvents_Unchecked(object sender, RoutedEventArgs e)
        {
            startTime.IsEnabled = true;
            endTime.IsEnabled = true;
            eventStartTime.Text = null;
            eventStartTime.IsEnabled = false;
            eventNum.Text = null;
            eventNum.IsEnabled = false;
        }

        private void K_Means_Click(object sender, RoutedEventArgs e)
        {
            Pushpin pin = new Pushpin();
            Location tempLocation = new Location();
            foreach (var item in dataAnalysisViewModel.HitByK_Means())
            {
                tempLocation.Latitude = item.Latitude;
                tempLocation.Longitude = item.Longitude;
                pin.Location = tempLocation;
                pin.Background = new SolidColorBrush(ToMediaColor(System.Drawing.Color.FromName("Green")));
                myMap.Children.Add(pin);
            }
        }
    }
}
