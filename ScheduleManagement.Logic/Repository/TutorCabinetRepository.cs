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
       
        public Func<DateTime?, bool> CheckDate = (x => x != null && x >= DateTime.Today);

        public Func<string, bool> CheckAmount = (x => int.TryParse(x, out int intx) && intx > 0);

        public List<TutorCabinet> FormSchedule(DateTime? date, int? id)
        {
            return  _context.TutorCabinets.Where(t => t.Date == date && t.TutorId == id)
                .OrderBy(l => l.LessonOrder).ToList();
        }

        public bool CheckLesson(int lesson, DateTime date, int tutor)
        {
            return _context.TutorCabinets.Any(t => t.Date == date.Date && t.LessonOrder == lesson && t.TutorId == tutor);
        }


        public void CheckBindCabinet (int idcab, int idtut, DateTime date, int lessonord)
        {
            if (!(CheckLesson(lessonord, date, idtut)))
              {
              BindLesson(idcab, idtut, date, lessonord);
              }
            else
            {
                Message?.Invoke("Вы уже выбрали " + lessonord + " урок на эту дату");
            };


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

        public IEnumerable<Cabinet> FindCabinets(int? schoolNumber, int? lesson, DateTime? date, int? amount, bool? hasComputers, bool? hasWhiteboard)
        {
     
            if (hasComputers == true && hasWhiteboard == true)
            {
                return _context.Schools.Single(x => x.Number == schoolNumber).Cabinets.FindAll(x => x.HasComputers == hasComputers &&
                x.HasWhiteBoard == hasWhiteboard &&
                x.PlacesAmount >= amount).Where(l => !_context.TutorCabinets.Any(l1 => l1.CabinetId == l.ID && l1.Date == date && l1.LessonOrder == lesson));
            }
            else if (hasComputers == false && hasWhiteboard == true)
            {
                return _context.Schools.Single(x => x.Number == schoolNumber).Cabinets.FindAll(x =>
                x.HasWhiteBoard == hasWhiteboard &&
                x.PlacesAmount >= amount).Where(l => !_context.TutorCabinets.Any(l1 => l1.CabinetId == l.ID && l1.Date == date && l1.LessonOrder == lesson));
            }
            else if (hasComputers == true && hasWhiteboard == false)
            {
                return _context.Schools.Single(x => x.Number == schoolNumber).Cabinets.FindAll(x => x.HasComputers == hasComputers &&
                x.PlacesAmount >= amount).Where(l => !_context.TutorCabinets.Any(l1 => l1.CabinetId == l.ID && l1.Date == date && l1.LessonOrder == lesson));
            }
            else
            {
                return _context.Schools.Single(x => x.Number == schoolNumber).Cabinets.FindAll(x =>
               x.PlacesAmount >= amount).Where(l => !_context.TutorCabinets.Any(l1 => l1.CabinetId == l.ID && l1.Date == date && l1.LessonOrder == lesson));
            }
        }

        public void BindLesson(int idcab, int idtut, DateTime date, int lessonord)
        {
            if (!(_context.TutorCabinets.Any(t => t.CabinetId == idcab && t.Date == date && t.LessonOrder == lessonord)))
            {
                _context.TutorCabinets.Add(new TutorCabinet { CabinetId = idcab, Date = date, LessonOrder = lessonord , TutorId = idtut});
                _context.SaveChanges();
                Message?.Invoke("Кабинет успешно забронирован");
            }
        }

        public void DeleteBindedLesson (int cabinetid, DateTime date, int lessonorder)
        {
            _context.TutorCabinets.Remove(_context.TutorCabinets.First(t => t.CabinetId == cabinetid && t.Date == date && t.LessonOrder == lessonorder));
            _context.SaveChanges();
            Message?.Invoke("Бронь кабинета успешно удалена");
        }
    }
}
