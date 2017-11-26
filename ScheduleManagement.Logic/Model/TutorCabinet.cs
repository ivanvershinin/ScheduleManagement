using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement.Logic.Model
{
    public class TutorCabinet
    {
        [Key, Column(Order = 0)]
        public int CabinetId { get; set; }
        [Required, Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LessonOrder { get; set; }
        [Required, Key, Column(Order = 2), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public DateTime Date { get; set; }
        
        public Cabinet Cabinet { get; set; }
        public Tutor Tutor { get; set; }
        
    }
}
