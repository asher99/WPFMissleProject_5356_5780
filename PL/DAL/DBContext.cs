using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;


namespace DAL
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DBContext")
        {
        }

        public DbSet<Report> Reports { get; set; }
        //public DbSet<Event> Events { get; set; }
        public DbSet<Hit> Hits { get; set; }

    }
}
