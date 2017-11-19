using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement.Logic.Model
{
    class Cabinet
    {
        [Key, Column(Order = 0)]
        public int ID { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public bool HasComputers { get; set; }
        public bool HasWhiteBoard { get; set; }
        public int PlacesAmount { get; set; }

        public virtual ICollection<TutorCabinet> TutorCabinets { get; set; }
    }
}
