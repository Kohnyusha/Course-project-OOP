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
    /// Логика взаимодействия для MainDiets.xaml
    /// </summary>
    public partial class MainDiets : Page
    {
        public static List<ListOfDiets> listOfDiets = new List<ListOfDiets>();

        public MainDiets()
        {
            InitializeComponent();
            listOfDiets.Clear();
        }

        private void dinner_Click(object sender, RoutedEventArgs e)
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
                        if (reader.GetValue(2).ToString() == "Ужин")
                        {
                            //string name, string type, string discriptions, int id
                            listOfDiets.Add(new ListOfDiets(reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), Convert.ToInt32(reader.GetValue(0))));
                        }
                    }
                    reader.Close();
                }
                InfoUser.title = "Ужин";
                NavigationService.Navigate(new DietsInfo());


            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }

        private void lunch_Click(object sender, RoutedEventArgs e)
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
                        if (reader.GetValue(2).ToString() == "Обед")
                        {
                            //string name, string type, string discriptions, int id
                            listOfDiets.Add(new ListOfDiets(reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), Convert.ToInt32(reader.GetValue(0))));
                        }
                    }
                    reader.Close();
                }
                InfoUser.title = "Обед";
                NavigationService.Navigate(new DietsInfo());
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }

        private void breakfast_Click(object sender, RoutedEventArgs e)
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
                        if (reader.GetValue(2).ToString() == "Завтрак")
                        {
                            //string name, string type, string discriptions, int id
                            listOfDiets.Add(new ListOfDiets(reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), Convert.ToInt32(reader.GetValue(0))));
                        }
                    }
                    reader.Close();
                }
                InfoUser.title = "Завтрак";
                NavigationService.Navigate(new DietsInfo());

            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }
    }
}
