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
            using (var unitOfWork = new UnitOfWork())
            {
                DGShow.ItemsSource = unitOfWork.CRs.Items;
                unitOfWork.Complete();
            }
        }

        private void Bind_Click(object sender, RoutedEventArgs e)
        {
            //запрос + нужна ли проверка чтобы один препод 2 ряда не привязывал кабинет !!!1
            using (var unitOfWork = new UnitOfWork())
            {
                
                var SelectedCabinet = DGShow.SelectedItem as Cabinet;
                if (SelectedCabinet != null)
                {
                    var idcabinet = SelectedCabinet.ID;
                    var iduser = Storage.Default.CurrentID;
                    var datechosen = Storage.Default.DateChosen;
                    var lessonorder = Storage.Default.LessonChosen;
                    unitOfWork.TCRs.BindLesson(idcabinet, iduser, datechosen, lessonorder);
                }
            }
        }

        private void ReturnToAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PagesStorage.Default.GetAccountPage());
            //конец

        }
    }
}
