using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement.Logic.Model
{
    public class School
    {
        [Key, Column(Order = 0)]
        public int ID { get; set; }
        public int Number { get; set; }
        public string Adress { get; set; }

        public virtual List<Cabinet> Cabinets { get; set; }
    }
}
