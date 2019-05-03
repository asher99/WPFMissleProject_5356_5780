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
        public Func<double, string> XFormatter { get; set; }
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
                new StackedAreaSeries
                {
                    Title = "Africa",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(1950, 1, 1), .228),
                        new DateTimePoint(new DateTime(1960, 1, 1), .285),
                        new DateTimePoint(new DateTime(1970, 1, 1), .366),
                        new DateTimePoint(new DateTime(1980, 1, 1), .478),
                        new DateTimePoint(new DateTime(1990, 1, 1), .629),
                        new DateTimePoint(new DateTime(2000, 1, 1), .808),
                        new DateTimePoint(new DateTime(2010, 1, 1), 1.031),
                        new DateTimePoint(new DateTime(2013, 1, 1), 1.110)
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "N & S America",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(1950, 1, 1), .339),
                        new DateTimePoint(new DateTime(1960, 1, 1), .424),
                        new DateTimePoint(new DateTime(1970, 1, 1), .519),
                        new DateTimePoint(new DateTime(1980, 1, 1), .618),
                        new DateTimePoint(new DateTime(1990, 1, 1), .727),
                        new DateTimePoint(new DateTime(2000, 1, 1), .841),
                        new DateTimePoint(new DateTime(2010, 1, 1), .942),
                        new DateTimePoint(new DateTime(2013, 1, 1), .972)
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Asia",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(1950, 1, 1), 1.395),
                        new DateTimePoint(new DateTime(1960, 1, 1), 1.694),
                        new DateTimePoint(new DateTime(1970, 1, 1), 2.128),
                        new DateTimePoint(new DateTime(1980, 1, 1), 2.634),
                        new DateTimePoint(new DateTime(1990, 1, 1), 3.213),
                        new DateTimePoint(new DateTime(2000, 1, 1), 3.717),
                        new DateTimePoint(new DateTime(2010, 1, 1), 4.165),
                        new DateTimePoint(new DateTime(2013, 1, 1), 4.298)
                    },
                    LineSmoothness = 0
                },
                new StackedAreaSeries
                {
                    Title = "Europe",
                    Values = new ChartValues<DateTimePoint>
                    {
                        new DateTimePoint(new DateTime(1950, 1, 1), .549),
                        new DateTimePoint(new DateTime(1960, 1, 1), .605),
                        new DateTimePoint(new DateTime(1970, 1, 1), .657),
                        new DateTimePoint(new DateTime(1980, 1, 1), .694),
                        new DateTimePoint(new DateTime(1990, 1, 1), .723),
                        new DateTimePoint(new DateTime(2000, 1, 1), .729),
                        new DateTimePoint(new DateTime(2010, 1, 1), .740),
                        new DateTimePoint(new DateTime(2013, 1, 1), .742)
                    },
                    LineSmoothness = 0
                }
            };

            XFormatter = val => new DateTime((long)val).ToString("yyyy");
            YFormatter = val => val.ToString("N") + " M";

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
