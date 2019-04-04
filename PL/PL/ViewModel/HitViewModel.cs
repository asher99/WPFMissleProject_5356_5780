using BE;
using PL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.Commands;

namespace PL.ViewModel
{
    public class HitViewModel : INotifyPropertyChanged, IHitViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MissleModel currentModel { set; get; }

        public Hit incomingHit
        {
            get { return currentModel.incomingHit; }
            set
            {
                currentModel.incomingHit = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("incomingHit"));
            }
        }

        AddHitCommand addHitCommand { set; get; }

        public HitViewModel()
        {
            currentModel = new MissleModel();
            addHitCommand = new AddHitCommand(this);
        }

    }
}
