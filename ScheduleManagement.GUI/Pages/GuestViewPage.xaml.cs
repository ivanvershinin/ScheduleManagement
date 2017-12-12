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
                unitOfWork.Complete();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PagesStorage.Default.GetStartingPage());

        }

        private void ViewSched_Click(object sender, RoutedEventArgs e)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.TCRs.Message += ShowMessage;
                var sch = School.SelectedItem as School;
                var schid = sch?.ID;
                var tut = Tutors.SelectedItem as Tutor;
                var tutid = tut?.ID;
                var date = Date.SelectedDate;
                if (unitOfWork.SRs.CheckData(date, schid, tutid))
                {
                    DGShowSchedule.ItemsSource =  unitOfWork.TCRs.FormSchedule(date, tutid);
                }
            }
        }

        private void School_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            using (var unitOfWork = new UnitOfWork())
            {               
                var sch = School.SelectedItem as School;
                var schid = sch.ID;              
                Tutors.ItemsSource =  unitOfWork.SRs.FormTutors(schid);
            }
        }

        private void ShowMessage (string message)
        {
            MessageBox.Show(message);
        }
    }
}
