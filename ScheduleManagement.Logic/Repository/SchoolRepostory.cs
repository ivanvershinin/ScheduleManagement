using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManagement.Logic.Model;

namespace ScheduleManagement.Logic.Repository
{
    public class SchoolRepostory : Repository<School>
    {
        public SchoolRepostory(Context context) : base(context)
        {
            Items = context.Schools.ToList();
        }

        public List<Tutor> FormTutors (int schid)
        {
            List<Tutor> list = new List<Tutor>();
            var r = _context.Cabinets.Where(t => t.School.ID == schid)
                .Join(_context.TutorCabinets,
                cabinet => cabinet.ID,
                tutorcabinet => tutorcabinet.CabinetId,
                (cabinet, tutorcabinet) => new { tutorcabinet.Tutor })
                .Distinct();

            foreach (var item in r)
            {
                var a = item.Tutor as Tutor;
                list.Add(a);
            } return list;
        }
    }
}
