using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    public class ScheduleContext: DbContext
    {
        public DbSet<Person> person { get; set; }
        private string db_path { get; set; }

        public ScheduleContext()
        {
            db_path = Path.Join("contact");
            Database.EnsureCreated();
        }
         protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite($"Data Source={db_path}");
        }
     
    }
}
