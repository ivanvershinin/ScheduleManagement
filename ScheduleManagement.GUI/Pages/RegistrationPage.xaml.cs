using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScheduleManagement.Logic;
using ScheduleManagement.Logic.Repository;


namespace ScheduleManagement.GUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(PagesStorage.Default.GetStartingPage());
            //конец
        }

        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.TRs.Message += ShowMessage;
                if (unitOfWork.TRs.CheckRegistration(TBName.Text, TBSurname.Text, TBEmail.Text, PBPassword.Password))
                {
                    TBName.Clear();
                    TBSurname.Clear();
                    TBEmail.Clear();
                    PBPassword.Clear();
                }

            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
