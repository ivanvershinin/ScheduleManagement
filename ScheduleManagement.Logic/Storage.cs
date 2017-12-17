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
        public int SchoolNumber { get; set; }
        public int StudentAmount { get; set; }
        public bool BoardNeed { get; set; }
        public bool CompNeed { get; set; }
        private static Storage _default;
        public List<int> lessons = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

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
