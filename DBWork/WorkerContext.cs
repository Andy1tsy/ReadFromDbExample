using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWork
{
    public class WorkerContext : DbContext
    {
        public WorkerContext() : base("DbConnection") { } // DbConnection
        public DbSet<Worker> Workers { get; set; }
      //  public DbSet<Speciality> Specialities { get; set; }
    }
}
