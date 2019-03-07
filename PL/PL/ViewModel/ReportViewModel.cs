using GalaSoft.MvvmLight;
using PL.Commands;
using PL.Model;
using System.ComponentModel;
using BE;

namespace PL.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ReportViewModel : ViewModelBase, IReportViewModel, INotifyPropertyChanged

    {
        public MissleModel currentModel { set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Report incomingReport
        {
            get { return currentModel.incomingReport; }
            set
            {
                currentModel.incomingReport = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("incomingReport"));
            }
        }

        public AddReportCommand addReportCommand { set; get; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public ReportViewModel()
        {
            currentModel = new MissleModel();
            addReportCommand = new AddReportCommand(this);

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }
}