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
using ScheduleManagement.Logic.Model;

namespace ScheduleManagement.GUI.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewPage.xaml
    /// </summary>
    public partial class ViewPage : Page
    {
        public ViewPage()
        {
            InitializeComponent();
            RefreshList();
        }

        private void Bind_Click(object sender, RoutedEventArgs e)
        {
            if (DGShow.SelectedItem is Cabinet SelectedCabinet)
            {
                using (var unitOfWork = new UnitOfWork())
                {
                   unitOfWork.TCRs.Message += MessageShow;
                   unitOfWork.TCRs.CheckBindCabinet(SelectedCabinet.ID, Storage.Default.CurrentID, Storage.Default.DateChosen, Storage.Default.LessonChosen);
                }

                RefreshList();
            }
            else { MessageBox.Show("Выберите кабинет"); };

        }

        private void ReturnToAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PagesStorage.Default.GetAccountPage());
            //конец
        }

        public void RefreshList()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                DGShow.ItemsSource = unitOfWork.TCRs.FindCabinets(Storage.Default.SchoolNumber, Storage.Default.LessonChosen, Storage.Default.DateChosen, Storage.Default.StudentAmount, Storage.Default.CompNeed, Storage.Default.BoardNeed);
                if (DGShow.Items.Count == 0)
                    MessageBox.Show("Кабинетов, удовлетворящих Вашим условиям, нет.");

            }
        }

        private void MessageShow(string message)
        {
            MessageBox.Show(message);
        }
    }
}
