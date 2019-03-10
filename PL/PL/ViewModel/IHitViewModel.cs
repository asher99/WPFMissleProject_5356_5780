using BE;
using PL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.ViewModel
{
    public interface IHitViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;
        MissleModel currentModel { set; get; }
        Hit incomingHit { set; get; }
    }
}
