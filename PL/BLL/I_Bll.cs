using BE;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface I_Bll
    {
        List<GeoCoordinate> k_Means(List<Report> report_List, int k);

    }
}
