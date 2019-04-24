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
    /// Interaction logic for New_Report.xaml
    /// </summary>
    public partial class New_Report : Window
    {
        public ReportViewModel reportViewModel { set; get; }
        public New_Report()
        {
            
            reportViewModel = new ReportViewModel();
            this.DataContext = reportViewModel;
            InitializeComponent();            
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReportLocation_TextChanged(object sender, RoutedEventArgs e)
        {
            reportViewModel.TextChange(Location.Text);
        }
    }
}
