using System;
using System.Collections.Generic;
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
        //MissleModel IReportViewModel.currentModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //Report IReportViewModel.incomingReport { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

