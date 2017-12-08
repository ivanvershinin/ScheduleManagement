﻿using ScheduleManagement.Logic;
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
           
            using (var unitOfWork = new UnitOfWork())
            {
                var id = Storage.Default.CurrentID;
                DGShowSchedule.ItemsSource = unitOfWork.TCRs.FormSchedule(DP.SelectedDate, id);
            }
        }

        private void Update(int i)
        {

        }
    }
}
