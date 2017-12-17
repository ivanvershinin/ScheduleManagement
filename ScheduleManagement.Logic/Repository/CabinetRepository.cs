using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManagement.Logic.Model;

namespace ScheduleManagement.Logic.Repository
{
    public class CabinetRepository : Repository<Cabinet>
    {
        public event Action<string> Message;

        public CabinetRepository(Context context) : base(context)
        {
            try
            {
                Items = context.Cabinets.ToList();
            } catch { Message?.Invoke("Время ожидания подключения истекло"); }
        }
    }
}
