using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using BE;
namespace DAL
{
    public class Dal_imp : IDAL
    {
        public async void addReport(Report _report)
        {
            if (getReport(_report.EventID) != null)
            {
                return;
                //throw new Exception("you have entered this report already!");
            }
            using (var ctx = new DBContext())
            {
                ctx.Reports.Add(_report);
                await ctx.SaveChangesAsync();
            }
        }       

        public async void removeReport(Report _report)
        {
            if (getReport(_report.EventID) == null)
                return;
            using (var ctx = new DBContext())
            {
                ctx.Reports.Remove(_report);
                await ctx.SaveChangesAsync();
            }

        }
        public async void updateReport(Report _report)
        {
            if (getReport(_report.EventID) == null)
                return;
            using (var ctx = new DBContext())
            {
                ctx.Entry(_report);
                ctx.Reports.AddOrUpdate(_report);
                await ctx.SaveChangesAsync();
            }
        }

        public async void addHit(Hit _hit)
        {
            if (getHit(_hit.EventID) != null)
            {
                return;
                // throw new Exception("you have entered this hit already!");
            }
            using (var ctx = new DBContext())
            {
                ctx.Hits.Add(_hit);
                await ctx.SaveChangesAsync();
            }

        }

        public async void removeHit(Hit _hit)
        {
            if (getHit(_hit.EventID) == null)
                return;
            using (var ctx = new DBContext())
            {
                ctx.Hits.Remove(_hit);
                await ctx.SaveChangesAsync();
            }
        }

         
        public async void updateHit(Hit _hit)
        {
            if (getHit(_hit.EventID) == null)
                return;
            using (var ctx = new DBContext())
            {
                ctx.Entry(_hit);
                ctx.Hits.AddOrUpdate(_hit);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<List<Report>> getAllReports()
        {
            List<Report> reports;
            using (var ctx = new DBContext())
            {
                reports = await (from _report in ctx.Reports
                                 select _report).ToListAsync();
            }
            return reports;
        }


        public Report getReport(int id)
        {
            Report report;
            using ( var ctx = new DBContext())
            {
                report = ctx.Reports.SingleOrDefault(r => r.EventID == id);
            }
            return report;
        }

        public Hit getHit(int id)
        {
            Hit hit;
            using (var ctx = new DBContext())
            {
                hit = ctx.Hits.SingleOrDefault(r => r.EventID == id);
            }
            return hit;
        }

        public async Task<List<Hit>> getAllHits()
        {
            List<Hit> hits;
            using (var ctx = new DBContext())
            {
                hits = await (from _hit in ctx.Hits
                                select _hit).ToListAsync();
            }
            return hits;
        }
    }
}
