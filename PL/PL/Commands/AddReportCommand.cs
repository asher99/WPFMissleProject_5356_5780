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
            foreach (var item in values)
            {
                if (item == null)
                {
                    result = false;
                }
            }
            return result;
        }

        public void Execute(object parameter)
        {
            var values = (object[])parameter;
            Report report = new Report();
            report.name = (string)values[0];
            report.timeOfReport = (DateTime)values[1];
            report.address = (GeoCoordinate)values[2];///convert the location to geo coordinate
            report.numOfBombs = (int)values[3];
            CurrentVM.incomingReport = report;
        }
    }
}

