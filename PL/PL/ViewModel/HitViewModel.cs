using BE;
using PL.Model;
using GoogleMapsApi.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.Commands;
using System.Collections.ObjectModel;

namespace PL.ViewModel
{
    public class HitViewModel : INotifyPropertyChanged, IHitViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> locations { get; set; }
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

        public void TextChange(string leters)
        {
            if (currentModel.checkLocations(leters))
            {
                locations = new ObservableCollection<string>(currentModel.locations);
                locations.CollectionChanged += locations_CollectionChanged;
            }
            return;
        }

        private void locations_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ///////do the observer
            return;

        }

        AddHitCommand addHitCommand { set; get; }

        public HitViewModel()
        {
            currentModel = new MissleModel();
            addHitCommand = new AddHitCommand(this);
            locations = new ObservableCollection<string>(currentModel.locations);
        }

    }
}
