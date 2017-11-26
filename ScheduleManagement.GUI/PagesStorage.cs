using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManagement.GUI.Pages;

namespace ScheduleManagement.GUI
{
    class PagesStorage
    {
        private static PagesStorage _default;

        private PagesStorage() { }

        public static PagesStorage Default
        {
            get
            {
                return _default ?? (_default = new PagesStorage());
            }
        }

        public AccountPage GetAccountPage()
        {
            return new AccountPage();
        }
        public LoginPage GetLoginPage()
        {
            return new LoginPage();
        }
        public RegistrationPage GetRegistrationPage()
        {
            return new RegistrationPage();
        }
        public StartingPage GetStartingPage()
        {
            return new StartingPage();
        }
        public ViewPage GetViewPage()
        {
            return new ViewPage();
        }

    }
}
