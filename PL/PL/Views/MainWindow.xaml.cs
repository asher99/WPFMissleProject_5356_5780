using PL.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Report_Click(object sender, RoutedEventArgs e)
        {
            New_Report report = new New_Report();
            report.Show();
        }

        private void VerifiedHits_Click(object sender, RoutedEventArgs e)
        {
            New_Hit hit = new New_Hit();
            hit.Show();
        }

        private void DataAnalysis_Click(object sender, RoutedEventArgs e)
        {
            Data_Analysis data_Analysis = new Data_Analysis();
            data_Analysis.Show();
        }

        private void BrowseReports_Click(object sender, RoutedEventArgs e)
        {
            Browse_Report browse_Report = new Browse_Report();
            browse_Report.Show();
        }
    }
}
