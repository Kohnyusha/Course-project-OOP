using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Trainer.Menu.TreiningPage
{
    /// <summary>
    /// Логика взаимодействия для MainTreiningPage.xaml
    /// </summary>
    public partial class MainTreiningPage : Page
    {
        public static List<ListOfTreinings> ListOfTreinings = new List<ListOfTreinings>();

        public MainTreiningPage()
        {
            InitializeComponent();
            ListOfTreinings.Clear();
        }

        private void Razminka_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectToDB.Connect.Conn();
                //create instanace of database connection
                using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                {
                    
                    conn.Open();//откр соедин с сервером
                    string sql = "SELECT * FROM Trainings";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if(reader.GetValue(1).ToString() == "Разминка")
                        {
                            //доб список коллекции
                            ListOfTreinings.Add(new ListOfTreinings(reader.GetValue(2).ToString(),reader.GetValue(3).ToString(),reader.GetValue(4).ToString(),Convert.ToInt32(reader.GetValue(0))));
                        }
                    }
                    reader.Close();//обяз, закрывает чтение таблицы
                }
                InfoUser.title = "Разминка";
                NavigationService.Navigate(new InfoTreining());

            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }

        private void Rasstazka_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectToDB.Connect.Conn();
                //create instanace of database connection
                using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                {

                    conn.Open();
                    string sql = "SELECT * FROM Trainings";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetValue(1).ToString() == "Расстяжка")
                        {
                            ListOfTreinings.Add(new ListOfTreinings(reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), Convert.ToInt32(reader.GetValue(0))));
                        }
                    }
                    reader.Close();
                }
                InfoUser.title = "Расстяжка";
                NavigationService.Navigate(new InfoTreining());

            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }

        private void ypraz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectToDB.Connect.Conn();
                //create instanace of database connection
                using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                {

                    conn.Open();
                    string sql = "SELECT * FROM Trainings";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetValue(1).ToString() == "Упражнение")
                        {
                            ListOfTreinings.Add(new ListOfTreinings(reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), Convert.ToInt32(reader.GetValue(0))));
                        }
                    }
                    reader.Close();
                }
                InfoUser.title = "Упражнения с инветарем";
                NavigationService.Navigate(new InfoTreining());

            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }

        private void treining_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectToDB.Connect.Conn();
                //create instanace of database connection
                using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                {

                    conn.Open();
                    string sql = "SELECT * FROM Trainings";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetValue(1).ToString() == "Тренировка")
                        {
                            ListOfTreinings.Add(new ListOfTreinings(reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), Convert.ToInt32(reader.GetValue(0))));
                        }
                    }
                    reader.Close();
                }
                InfoUser.title = "Тренировка на верхнюю часть тела";
                NavigationService.Navigate(new InfoTreining());

            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }

    }
}
