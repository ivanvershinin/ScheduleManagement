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

        public event Action<string> Message;
        public TutorCabinetRepository(Context context) : base(context)
        {
            Items = context.TutorCabinets.ToList();


        }
        static int intx;

        public Func<DateTime?, bool> CheckDate = (x => x != null && x >= DateTime.Today);


        public Func<string, bool> CheckAmount = (x => int.TryParse(x, out intx) && intx > 0);

        public List<TutorCabinet> FormSchedule(DateTime? date, int? id)
        {

            var r = _context.TutorCabinets
                  .Where(t => t.Date == date && t.TutorId == id).ToList();
            return r;
        }



        public bool CheckData(string amount, DateTime? date, int? schoolNumber, int? lesson)
        {
            if (!CheckDate(date))
            {
                Message?.Invoke("Введите дату, начиная с сегодняшней");
                return false;
            }

            else if (!CheckAmount(amount))
            {
                Message?.Invoke("Введите число, большее 0");
                return false;

            }
            else if (schoolNumber == null)
            {
                Message?.Invoke("Выберите школу");
                return false;


            }
            else if (lesson == null)
            {
                Message?.Invoke("Выберите урок");
                return false;


            }
            else
            return true;
        }
        public IEnumerable<Cabinet> FindCabinets(string schoolAddress, int? lesson, DateTime? date, int? amount, bool? hasComputers, bool? hasWhiteboard)
        {
            var one = _context.Schools.Single(x => x.Adress == schoolAddress).Cabinets.FindAll(x => x.HasComputers == hasComputers &&
            x.HasWhiteBoard == hasWhiteboard &&
            x.PlacesAmount >= amount);
            var two = one.Where(l => !_context.TutorCabinets.Any(l1 => l1.CabinetId == l.ID && l1.Date == date && l1.LessonOrder == lesson));
            return two;
        }

        public void BindLesson(int idcab, int idtut, DateTime date, int lessonord)
        {
            if (!(_context.TutorCabinets.Any(t => t.CabinetId == idcab && t.Date == date && t.LessonOrder == lessonord)))
            {
                _context.TutorCabinets.Add(new TutorCabinet { CabinetId = idcab, Date = date, LessonOrder = lessonord , TutorId = idtut});
                _context.SaveChanges();
            }
        }
    }
}
