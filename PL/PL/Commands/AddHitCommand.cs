using BE;
using PL.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PL.Commands
{
    class AddHitCommand : ICommand
    {
        private IHitViewModel CurrentVM;

        public AddHitCommand(IHitViewModel CurrentVM)
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
            Hit hit = new Hit();
            //hit.locationImage = (Image)values[0];
            hit.timeOfHit = (DateTime)values[1];
            GeoCoordinate coord = (GeoCoordinate)values[2];
            hit.Latitude = coord.Latitude;
            hit.Longitude = coord.Longitude;
            CurrentVM.incomingHit = hit;
        }
    }
}
