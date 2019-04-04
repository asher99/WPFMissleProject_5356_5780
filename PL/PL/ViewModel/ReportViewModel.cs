using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using PL.Commands;
using PL.Model;

namespace PL.ViewModel
{
    public class ReportViewModel : IReportViewModel, INotifyPropertyChanged

    {
        public MissleModel currentModel { set; get; }
        public ObservableCollection<string> locations { get; set; }
        public AddReportCommand addReportCommand { set; get; }
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

        public void TextChange(string leters)
        {
            if (currentModel.checkLocations(leters))
            {
                locations = new ObservableCollection<string>(currentModel.locations);
                locations.CollectionChanged += locations_CollectionChanged;
            }
        }

        private void locations_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ///////do the observer
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public ReportViewModel()
        {
            currentModel = new MissleModel();
            addReportCommand = new AddReportCommand(this);
        }
    }
}

