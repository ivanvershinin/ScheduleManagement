using ScheduleManagement.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement.Logic.Interfaces
{
    interface ITutorRepository
    {
        void AddTutor(Tutor tutor);

        bool CheckRegistration(string name, string surname, string email, string password);

        bool CheckLogin(string email, string password);

        IEnumerable<Tutor> CheckEmail(string email);

        IEnumerable<Tutor> CheckPassword(string email, string password);

    }
}
