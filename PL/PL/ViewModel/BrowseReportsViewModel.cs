using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using PL.Model;

namespace PL.ViewModel
{
    public class BrowseReportsViewModel
    {
        public MissleModel currentModel { set; get; }
        public ObservableCollection<Report> North { get; set; }
        public ObservableCollection<Report> South { get; set; }
        public ObservableCollection<Report> Center { get; set; }
        public ObservableCollection<Report> Other { get; set; }

        //public int North { set; get; }

        public BrowseReportsViewModel()
        {
            North = new ObservableCollection<Report>();
            South = new ObservableCollection<Report>();
            Center = new ObservableCollection<Report>();
            Other = new ObservableCollection<Report>();
        }

        public async void getAllReports()
        {
            var allreport = await currentModel.allReports();
            foreach (var item in allreport)
            {
                if (true)
                {
                    North.Add(item);
                }
                if (true)
                {
                    South.Add(item);
                }
                if (true)
                {
                    Center.Add(item);
                }
                else
                {
                    Other.Add(item);
                }
            }

        }
    }
}
