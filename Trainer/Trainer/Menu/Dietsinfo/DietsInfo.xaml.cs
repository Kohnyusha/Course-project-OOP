using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Trainer.Menu.DietsInfo
{
    /// <summary>
    /// Логика взаимодействия для DietsInfo.xaml
    /// </summary>
    public partial class DietsInfo : Page
    {
        public static string str;
        public DietsInfo()
        {
            InitializeComponent();
            ListView.Items.Clear();
            addTreining();
            titleOfTreining.Text = InfoUser.title;
        }



        private void back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainDiets());
        }

        public void addTreining()
        {

            for (int i = 0; i <= MainDiets.listOfDiets.Count - 1; i++)
            {
                ListView.Items.Add(MainDiets.listOfDiets[i].Name);
            }
        }



        private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!String.IsNullOrEmpty(str))
            {
                NavigationService.Navigate(new DietsStart());
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            str = (string)ListView.SelectedItem;
        }

        private void FindTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.Items.Clear();
            MainDiets.listOfDiets.Clear();

            if (!String.IsNullOrEmpty(FindTextBox.Text))
            {
                try
                {
                    ConnectToDB.Connect.Conn();
                    //create instanace of database connection
                    using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                    {

                        conn.Open();
                        string sql = "SELECT * FROM Diets";
                        SqlCommand command = new SqlCommand(sql, conn);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.GetValue(2).ToString() == InfoUser.title && reader.GetValue(1).ToString().ToLower().StartsWith(FindTextBox.Text.ToLower()))
                            {
                                MainDiets.listOfDiets.Add(new ListOfDiets(reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), Convert.ToInt32(reader.GetValue(0))));
                            }
                        }
                        reader.Close();
                    }
                    addTreining();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ошибка входа " + exp.Message);
                }
            }
            else
            {
                try
                {
                    ConnectToDB.Connect.Conn();
                    //create instanace of database connection
                    using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                    {

                        conn.Open();
                        string sql = "SELECT * FROM Diets";
                        SqlCommand command = new SqlCommand(sql, conn);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.GetValue(2).ToString() == InfoUser.title)
                            {
                                MainDiets.listOfDiets.Add(new ListOfDiets(reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), Convert.ToInt32(reader.GetValue(0))));
                            }
                        }
                        reader.Close();
                    }
                    addTreining();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ошибка входа " + exp.Message);
                }
            }
        }
    }
}
