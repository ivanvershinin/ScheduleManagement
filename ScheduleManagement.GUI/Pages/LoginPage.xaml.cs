﻿using System;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                if (unitOfWork.TRs.CheckLogin(TBEmail.Text, PBPassword.Password))
                    NavigationService.Navigate(PagesStorage.Default.GetAccountPage());
                else
                {
                    //.........................................ВРЕМЯ СООБЩЕНИЙ ОБ ОШИБКАХ И ДЕЛЕГАТА ДЛЯ НИХ НО МНЕ ЛЕНЬ
                }
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PagesStorage.Default.GetStartingPage());
            //конец

        }
         public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
