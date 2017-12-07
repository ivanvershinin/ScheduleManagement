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

        public Func<string, bool> CheckAmount = (x => int.TryParse(x, out intx) && intx > 0);

        public void FormSchedule(DateTime? date, string email)
        {
            if (date == null)
            {
                
            }
            else
            {

            }

        }


        public int SaveId(string email)
        {
             return _context.Set<Tutor>().First(x => x.Email == email).ID;
        }

        public bool CheckData(string amount, DateTime? date)
        {
            if (date == null)
            {
                Message?.Invoke("Введите дату");
                return false;
            }

            else if (!CheckAmount(amount))
            {
                Message?.Invoke("Введите число, большее 0");
                return false;

            }
            else
                return true;
        }
        
    }
}
