using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManagement.Logic.Model;

namespace ScheduleManagement.Logic
{
    public class Context : DbContext
    {
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<TutorCabinet> TutorCabinets { get; set; }


        public Context() : base("MSDb3")
        {

        }
    }
}
