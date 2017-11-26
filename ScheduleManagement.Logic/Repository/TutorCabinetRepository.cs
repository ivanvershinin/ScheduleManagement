using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManagement.Logic.Model;

namespace ScheduleManagement.Logic.Repository
{
    public class TutorCabinetRepository : Repository<TutorCabinet>
    {
        public TutorCabinetRepository(Context context) : base(context)
        {
            Items = context.TutorCabinets.ToList();
        }
    }
}
