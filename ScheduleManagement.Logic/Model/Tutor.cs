using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement.Logic.Model
{
    class Tutor
    {
        [Key, Column(Order = 0)]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<TutorCabinet> TutorCabinets { get; set; }
    }
}
