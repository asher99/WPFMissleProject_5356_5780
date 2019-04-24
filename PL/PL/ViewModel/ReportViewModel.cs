using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public TimeSpan thisTime=new TimeSpan();
        public ObservableCollection<string> locations
        {
            get
            {
                return new ObservableCollection<string>(currentModel.locations);
            }
        }
        public AddReportCommand addReportCommand { set; get; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

            }
            return;
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public ReportViewModel()
        {
            currentModel = new MissleModel();
            addReportCommand = new AddReportCommand(this);
            currentModel.PropertyChanged += (Property, EventArgs) =>
            {
                if (EventArgs.PropertyName == "locations")
                    OnPropertyChanged("locations");
            };
        }
    }
}

