using PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PL.Commands
{
    public class AddReportCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private IReportViewModel CurrentVM;

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

        }
    }
}
