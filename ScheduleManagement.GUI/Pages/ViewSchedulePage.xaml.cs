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
            NavigationService.Navigate(PagesStorage.Default.GetAccountPage());
            //все хорошо и пусто
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {       
            var id = Storage.Default.CurrentID;
            ShowSchedule(DP.SelectedDate, id);
        }

        private void DeleteBinding_Click(object sender, RoutedEventArgs e)
        {
            if (DGShowSchedule.SelectedItem is TutorCabinet SelectedCabinet)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    unitOfWork.TCRs.Message += MessageShow;
                    var tutcab = DGShowSchedule.SelectedItem as TutorCabinet;
                    var cabid = tutcab.CabinetId;
                    var date = tutcab.Date;
                    var lesson = tutcab.LessonOrder;
                    unitOfWork.TCRs.DeleteBindedLesson(cabid, date, lesson);
                    unitOfWork.Complete();
                    ShowSchedule(date, tutcab.TutorId);
                }               
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
