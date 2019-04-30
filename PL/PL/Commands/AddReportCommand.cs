using PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE;

namespace PL.Commands
{
    public class AddReportCommand : ICommand
    {
        private IReportViewModel CurrentVM;

        public AddReportCommand(IReportViewModel CurrentVM)
        {
            this.CurrentVM = CurrentVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result = true;
            var values = (object[])parameter;
            if(values != null) { 
            foreach (var item in values)
            {
                if (item == null)
                {
                    result = false;
                }
            }
            }
            return result;
            
        }

        public void Execute(object parameter)
        {
            var values = (object[])parameter;
            Report report = new Report();
            report.name = (string)values[0];
            report.timeOfReport = DateTime.Parse( values[1].ToString());
            // GeoCoordinate coord = (GeoCoordinate)values[2];
            report.Latitude = (double)values[2];//coord.Latitude;
            report.Longitude = (double)values[3];//  coord.Longitude;
            report.numOfBombs = int.Parse( values[4].ToString());
            CurrentVM.incomingReport = report;
        }
    }
}

