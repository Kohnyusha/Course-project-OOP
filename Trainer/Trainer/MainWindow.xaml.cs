using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

namespace Trainer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //загрузка первой страницы
            MainFrame.Content = new MainPage();

            if(InfoUser.IsAdmin == 0 )
            {
                AdminPanel.Visibility = Visibility.Hidden;
            }else if(InfoUser.IsAdmin == 1)
            {
                AdminPanel.Visibility = Visibility.Visible;
            }
        }

       
        private void trenningButton_Click(object sender, RoutedEventArgs e)
        {
            // переход на страницу
            MainFrame.NavigationService.Navigate(new Menu.Trenning());
        }



        private void Dieta_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Menu.Dieta());
        }

        private void Like_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Menu.Like());
        }

        private void InfoAboutProgramm_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Menu.InfoAboutProgramm());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
             Application.Current.Shutdown();
        }

        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Menu.AdminPanel());
        }

        private void InfoAboutUser_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Menu.User.UserPage());
        }
    }
}
