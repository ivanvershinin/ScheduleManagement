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
    /// Логика взаимодействия для AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
            using (var unitOfWork = new UnitOfWork())
            {
                CMBSchool.ItemsSource = unitOfWork.SRs.Items;
                //проблема с выбором номера урока, у нас нет всего набора отдельно, надо либо писать запрос либо хардкодить
                unitOfWork.Complete();
            }
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
