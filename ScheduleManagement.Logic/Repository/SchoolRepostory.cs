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

        public event Action<string> Message;

        public SchoolRepostory(Context context) : base(context)
        {
            Items = context.Schools.ToList();
        }

        public List<Tutor> FormTutors (int schid)
        {
            return _context.TutorCabinets.Where(t => t.Cabinet.School.ID == schid).Select(g => g.Tutor).Distinct().ToList();
        }

        public bool CheckData (DateTime? date, int? schid, int? tutorid)
        {
            if (date == null)
            {
                Message?.Invoke("Выберите дату");
                return false;
            }
            else if (schid == null)
            {
                Message?.Invoke("Выберите школу");
                return false;
            }
            else if (tutorid == null)
            {
                Message?.Invoke("Выберите учителя");
                return false;
            } 
            else return true;     
        }
    }
}
