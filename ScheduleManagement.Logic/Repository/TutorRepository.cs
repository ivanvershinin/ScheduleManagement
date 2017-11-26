using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManagement.Logic.Model;

namespace ScheduleManagement.Logic.Repository
{
    public class TutorRepository : Repository<Tutor>
    {
        public TutorRepository(Context context) : base(context)
        {
            Items = context.Tutors.ToList();
        }

    }
}
