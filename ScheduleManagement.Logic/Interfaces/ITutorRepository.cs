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

        string CheckLogin(string email, string password);

        bool EmailExists(string email);

        bool PasswordIsValid(string email, string password);

    }
}
