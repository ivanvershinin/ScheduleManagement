using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement.Logic
{
    public class Storage
    {
        public int CurrentID { get; set; }
        public int LessonChosen { get; set; }
        public DateTime DateChosen { get; set; }
        private static Storage _default;

        private Storage() { }

        public static Storage Default
        {
            get
            {
                return _default ?? (_default = new Storage());
            }
        }
    }
}
