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
using ScheduleManagement.Logic.Model;

namespace ScheduleManagement.GUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для GuestViewPage.xaml
    /// </summary>
    public partial class GuestViewPage : Page
    {
        public GuestViewPage()
        {
            InitializeComponent();
            using (var unitOfWork = new UnitOfWork())
            {
                School.ItemsSource = unitOfWork.SRs.Items;
            }
        }


        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PagesStorage.Default.GetStartingPage());

        }

        private void ViewSched_Click(object sender, RoutedEventArgs e)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.SRs.Message += ShowMessage;
                var sch = School.SelectedItem as School;
                var tut = Tutors.SelectedItem as Tutor;
                if (unitOfWork.SRs.CheckData(Date.SelectedDate, sch?.ID, tut?.ID))
                {
                    DGShowSchedule.ItemsSource =  unitOfWork.TCRs.FormSchedule(Date.SelectedDate, tut?.ID);
                    if (DGShowSchedule.Items.Count == 0)
                    MessageBox.Show("У данного преподавателя нет уроков на это число");
                }
            }
        }

        private void School_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {    if (School.SelectedItem is School school)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    Tutors.ItemsSource = unitOfWork.SRs.FormTutors(school.ID);
                    if (Tutors.Items.Count == 0)
                        MessageBox.Show("В данной школе нет зарегистрированных преподавателей");

                }
            }
        }

        private void ShowMessage (string message)
        {
            MessageBox.Show(message);
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Tutors.ItemsSource = null;
            School.SelectedItem = null;
            Date.SelectedDate = null;
            DGShowSchedule.ItemsSource = null;
        }

    }
}
