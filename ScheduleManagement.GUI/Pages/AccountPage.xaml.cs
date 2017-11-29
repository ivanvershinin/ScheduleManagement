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
            NavigationService.Navigate(PagesStorage.Default.GetViewSchedulePage());
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PagesStorage.Default.GetStartingPage());

        }

        private void AmountOfStudents_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBAmountOfStudents.Text == "Сколько учеников?")
                TBAmountOfStudents.Text = "";
        }

        private void AmountOfStudents_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TBAmountOfStudents.Text))
                TBAmountOfStudents.Text = "Сколько учеников?";

        }
    }
}
