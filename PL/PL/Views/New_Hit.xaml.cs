using PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PL.Views
{
    /// <summary>
    /// Interaction logic for New_Hit.xaml
    /// </summary>
    public partial class New_Hit : Window
    {
        public HitViewModel hitViewModel { set; get; }
        //public AutoCompleteBox

        public New_Hit()
        {
            InitializeComponent();
            hitViewModel = new HitViewModel();
            this.DataContext = hitViewModel;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HitLocation_TextChanged(object sender, RoutedEventArgs e)
        {
            hitViewModel.TextChange(location.Text);
        }
    }
}
