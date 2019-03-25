using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Dal_imp
    {
        public void addReport(Report _report)
        {
            using (var ctx = new DBContext())
            {
                ctx.Reports.Add(_report);
                ctx.SaveChanges();
            }
        }

        /*public void addEvent(Event _event)
        {
            using (var ctx = new DBContext())
            {
                ctx.Events.Add(_event);
                ctx.SaveChanges();
            }

        }*/

        public void addHit(Hit _hit)
        {
            using (var ctx = new DBContext())
            {
                ctx.Hits.Add(_hit);
                ctx.SaveChanges();
            }

        }

        public void removeReport(Report _report)
        {

        }

        /*public void removeEvent(Event _event)
        {

        }*/

        public void removeHit(Hit _hit)
        {

        }

        public void updateReport(Report _report)
        {

        }

        /*public void updateEvent(Event _event)
        {

        }*/

        public void updateHit(Hit _hit)
        {

        }

        public Report readReport()
        {
            return null;
        }

        /*public Event readEvent()
        {
            return null;

        }*/

        public Hit readHit()
        {
            return null;

        }
    }
}
