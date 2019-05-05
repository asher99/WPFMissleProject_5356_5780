using System;
using System.Collections.Generic;
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

        public int North { set; get; }

        public List<Report> getAllReports
        {
            set { }
            get
            {
                return null;//currentModel.allReports();                
            }
        }
    }
}
