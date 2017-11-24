using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement.Logic.Repository
{
    public abstract class Repository<T>
    {
        protected Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        public List<T> Items;

    }
}
