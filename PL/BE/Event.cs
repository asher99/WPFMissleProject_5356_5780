using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Event
    {
        public int IDOfEvent { set; get; }
        public DateTime beginningOfEvent { set; get; }
        public ICollection<Report> listOfReport { set; get; }
        public ICollection<Hit> listOfHit { set; get; }
    }
}
