using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Report
    {
        DateTime timeOfReport { get; set; }
        string name { get; set; }
        string address { get; set; } // Location
        int numOfBombs { get; set; }//kk
    }
}
