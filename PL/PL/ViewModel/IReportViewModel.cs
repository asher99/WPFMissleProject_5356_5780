using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using PL.Model;
using BE;

namespace PL.ViewModel
{
    public interface IReportViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;
        MissleModel currentModel { set; get; }
        Report incomingReport { set; get; }
    }
}
