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
                unitOfWork.Complete();
            }
            CMBLesson.ItemsSource = Storage.Default.lessons;
        }

        School school;
        int? lesson;

        private void ViewCabinets_Click(object sender, RoutedEventArgs e)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.TCRs.Message += ShowMessage;
                if (unitOfWork.TCRs.CheckData(TBAmountOfStudents.Text, DP.SelectedDate, school?.ID, lesson))
                {
                    UpdateSession();
                    NavigationService.Navigate(PagesStorage.Default.GetViewPage());
                }
            }
        }

        private void UpdateSession()
        {
            Storage.Default.DateChosen = (DateTime)DP.SelectedDate;
            Storage.Default.LessonChosen = (int)lesson;
            Storage.Default.SchoolNumber = school.Number;
            Storage.Default.StudentAmount = int.Parse(TBAmountOfStudents.Text);
            Storage.Default.BoardNeed = (bool)CBWhiteBoard.IsChecked;
            Storage.Default.CompNeed = (bool)CBComputers.IsChecked;

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

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void CMBSchool_Selected(object sender, RoutedEventArgs e)
        {
          school = CMBSchool.SelectedItem as School;
        }

        private void CMBLesson_Selected(object sender, RoutedEventArgs e)
        {
            lesson = CMBLesson.SelectedItem as int?;
        }
    }
}
