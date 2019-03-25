using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BLL;

namespace PL.Model
{
    public class MissleModel
    {
        BLL_imp currentBll;
        public MissleModel()
        {
            currentBll = new BLL_imp();
        }
        public Report incomingReport
        {
            get { return incomingReport; }
            set
            {
                incomingReport = value;
                currentBll.addReport(value);
            }
        }

        public Hit incomingHit
        {
            get { return incomingHit; }
            set
            {
                incomingHit = value;
                currentBll.addHit(value);

            }
        }

        

        

    }
}
