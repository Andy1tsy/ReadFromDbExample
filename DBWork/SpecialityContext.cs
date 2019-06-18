using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWork
{
    public class SpecialityContext : DbContext
    {
        public SpecialityContext() : base("DbConnection") { }
        public DbSet<Speciality> Specialities { get; set; }
    }
}
