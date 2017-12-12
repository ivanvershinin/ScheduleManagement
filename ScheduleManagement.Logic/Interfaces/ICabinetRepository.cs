using ScheduleManagement.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement.Logic.Interfaces
{
    interface ICabinetRepository
    {
        IEnumerable<Cabinet> GetSuitableCabinets(bool hasComputers, bool hasWhiteBoard, int studentsAmount, int schoolNumber);
    }
}
