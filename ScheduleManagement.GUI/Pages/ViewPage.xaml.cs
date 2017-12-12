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
            using (var unitOfWork = new UnitOfWork())
            {
                if (DGShow.SelectedItem is Cabinet SelectedCabinet)
                {
                    unitOfWork.TCRs.Message += MessageShow;
                    var idcabinet = SelectedCabinet.ID;
                    var iduser = Storage.Default.CurrentID;
                    var datechosen = Storage.Default.DateChosen;
                    var lessonorder = Storage.Default.LessonChosen;
                    if (!(unitOfWork.TCRs.CheckLesson(lessonorder, datechosen, iduser)))
                    {
                        unitOfWork.TCRs.BindLesson(idcabinet, iduser, datechosen, lessonorder);
                    }
                    else { MessageBox.Show("Вы уже выбрали " + lessonorder + " урок на эту дату"); };
                }
                else { MessageBox.Show("Выберите кабинет"); };
                RefreshList();
                unitOfWork.Complete();
            }
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
                var lessonord = Storage.Default.LessonChosen;
                var datechosen = Storage.Default.DateChosen;
                var schoolchosen = Storage.Default.SchoolNumber;
                var studentsam = Storage.Default.StudentAmount;
                var computers = Storage.Default.CompNeed;
                var board = Storage.Default.BoardNeed;
                DGShow.ItemsSource = unitOfWork.TCRs.FindCabinets(schoolchosen, lessonord, datechosen, studentsam, computers, board);
                unitOfWork.Complete();
            }
        }

        private void MessageShow(string message)
        {
            MessageBox.Show(message);
        }
    }
}
