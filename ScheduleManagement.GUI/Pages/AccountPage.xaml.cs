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

namespace ScheduleManagement.GUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
        }

        private void ViewCabinets_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PagesStorage.Default.GetViewPage());

        }

        private void ViewSchedule_Click(object sender, RoutedEventArgs e)
        {
            //пока не знаю чокак делать
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PagesStorage.Default.GetStartingPage());

        }
    }
}
