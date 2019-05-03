﻿using BE;
using Microsoft.Maps.MapControl.WPF;
using PL.Model;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.ViewModel
{
    class DataAnalysisViewModel
    {
        public MissleModel currentModel { set; get; }
        public DateTime start { set; get; }
        public DateTime end { set; get; }
        public string eventNum { set; get; } = "Numbers only";
        public string K_Means { set; get; } = "Numbers only";
        public List<Report> allCurrentReport
        {
            set { }
            get
            {
                if (end != null)
                {
                    allCurrentReport =  currentModel.getReportsByDates(start, end);
                }
                else
                {
                    DateTime tempend = start;
                    tempend.AddMinutes (10 * Convert.ToInt32(eventNum));
                    allCurrentReport =  currentModel.getReportsByDates(start, tempend);
                }
                return allCurrentReport;
            }
        }

        public List<GeoCoordinate> HitByK_Means()
        {
            return currentModel.HitByK_Means(allCurrentReport, Convert.ToInt32(K_Means));
        }

        public DataAnalysisViewModel()
        {
            allCurrentReport = new List<Report>();
            currentModel = new MissleModel();
            CenterLocation = new Location();
        }

        public Location CenterLocation
        {
            set { }
            get {
                CenterLocation = currentModel.Center(allCurrentReport);
                return CenterLocation;
            }
        }
    }
}
