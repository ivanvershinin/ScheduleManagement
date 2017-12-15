using ScheduleManagement.Logic;
using ScheduleManagement.Logic.Model;
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
    /// Логика взаимодействия для ViewSchedule.xaml
    /// </summary>
    public partial class ViewSchedulePage : Page
    {
        public ViewSchedulePage()
        {
            InitializeComponent();
        }
        private void ReturnToAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PagesStorage.Default.GetAccountPage()); //все хорошо и пусто
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {       
            ShowSchedule(DP.SelectedDate, Storage.Default.CurrentID);
        }

        private void DeleteBinding_Click(object sender, RoutedEventArgs e)
        {
            if (DGShowSchedule.SelectedItem is TutorCabinet SelectedCabinet)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    unitOfWork.TCRs.Message += MessageShow;
                    unitOfWork.TCRs.DeleteBindedLesson(SelectedCabinet.CabinetId, SelectedCabinet.Date, SelectedCabinet.LessonOrder);
                    //unitOfWork.Complete();
                    ShowSchedule(SelectedCabinet.Date, SelectedCabinet.TutorId);
                }               
            }
            else
            {
                MessageShow("Выберите запись");
            }

        }

        private void MessageShow(string message)
        {
            MessageBox.Show(message);
        }

        private void ShowSchedule(DateTime? date, int tutorid)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                DGShowSchedule.ItemsSource = unitOfWork.TCRs.FormSchedule(date, tutorid);
                unitOfWork.Complete();

            }
        }
    }
}
