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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using BLL;
using PL.ViewModel;
using BE;
namespace PL.Views
{
    /// <summary>
    /// Interaction logic for Browse_Report.xaml
    /// </summary>
    public partial class Browse_Report : Window
    {

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }


        public BrowseReportsViewModel browseViewModel { set; get; }

        public Browse_Report()
        {
            InitializeComponent();

            CreatePieChart();
   
            // DataContext = this;
            browseViewModel = new BrowseReportsViewModel();
            DataContext = browseViewModel;


            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Series 3",
                    Values = new ChartValues<double> { 4,2,7,2,7 },
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }
            };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
            YFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart
            SeriesCollection.Add(new LineSeries
            {
                Title = "Series 4",
                Values = new ChartValues<double> { 5, 3, 2, 4 },
                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 50,
                PointForeground = Brushes.Gray
            });

            //modifying any series values will also animate and update the chart
            SeriesCollection[3].Values.Add(5d);

            DataContext = this;
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

       public void CreatePieChart()
        {
            double north = 0, south = 0, center = 0, other = 0;
            Func<ChartPoint, string> labelPoint = chartPoint =>
              string.Format("{0:n0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            foreach(Report r in browseViewModel.getAllReports)
            {
                
                if (r.Latitude > 32.144343 && r.Latitude <= 33.333795 && r.Longitude > 34.217333 && r.Longitude < 35.672361)
                {
                    north++;
                }

                // center starts at herzelia 
                else if (r.Latitude > 31.571548 && r.Latitude <= 32.144343 && r.Longitude > 34.217333 && r.Longitude < 35.672361)
                {
                    center++;
                }

                // south starts at keriyt gat
                else if (r.Latitude > 29.497512 && r.Latitude <= 31.571548 && r.Longitude > 34.217333 && r.Longitude < 35.672361)
                {
                    south++;
                }
                else
                {
                    other++;
                }

            }

            pieChart1.Series = new SeriesCollection();
            PieSeries pie = new PieSeries();
            pie.Title = "North";
            pie.Values = new ChartValues<double> { north };
            pie.DataLabels = true;
            pie.LabelPoint = labelPoint;
            pieChart1.Series.Add(pie);

            //Series - Each Slice of the pie. 
            PieSeries pie1 = new PieSeries();
            pie1.Title = "Center";
            pie1.Values = new ChartValues<double> { center };
            pie1.DataLabels = true;
            pie1.LabelPoint = labelPoint;
            pieChart1.Series.Add(pie1);

            //Series - Each Slice of the pie. 
            PieSeries pie2 = new PieSeries();
            pie2.Title = "South";
            pie2.Values = new ChartValues<double> { south };
            pie2.DataLabels = true;
            pie2.LabelPoint = labelPoint;
            pieChart1.Series.Add(pie2);

            PieSeries pie3 = new PieSeries();
            pie2.Title = "Other";
            pie2.Values = new ChartValues<double> { other };
            pie2.DataLabels = true;
            pie2.LabelPoint = labelPoint;
            pieChart1.Series.Add(pie3);

            pieChart1.LegendLocation = LegendLocation.Top;
        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
            {
                series.PushOut = 0;
            }
           
            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

    }
}
