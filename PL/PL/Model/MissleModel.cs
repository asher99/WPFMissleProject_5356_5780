﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace PL.Model
{
    public class MissleModel
    {
        public MissleModel() { }
        public Report incomingReport { get; set; }
        public Hit incomingHit { get; set; }

        public void AddHit(Hit hit)
        {
            ///add hit to the bll
        }

        public void AddReport(Report report)
        {
            ///add report to the bll
        }

    }
}
