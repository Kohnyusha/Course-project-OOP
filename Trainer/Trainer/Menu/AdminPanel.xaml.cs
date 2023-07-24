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

namespace Trainer.Menu
{
     public class MyItem//шаблон по которому загруж данные (листа)
     {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Discriptions { get; set; }
    }
    public partial class AdminPanel : Page
    {
        MyItem myItem;
        bool canDelete;
        public string id="0";


        public AdminPanel()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            int index = comboBox.SelectedIndex;//номер выдел эл

            ListFromDb.Items.Clear();

            if(index ==0)
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
                            ListFromDb.Items.Add(new MyItem { Id = reader.GetValue(0).ToString(),Type="Тренировка",  Name = reader.GetValue(2).ToString(), Discriptions = reader.GetValue(4).ToString() });
                        }
                        reader.Close();

                        sql = "SELECT * FROM Diets";
                        command = new SqlCommand(sql, conn);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ListFromDb.Items.Add(new MyItem { Id = reader.GetValue(0).ToString(), Type = "Диета", Name = reader.GetValue(1).ToString(), Discriptions = reader.GetValue(3).ToString() });
                        }
                        reader.Close();
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ошибка входа " + exp.Message);
                }
            }
            if (index == 1)
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
                            ListFromDb.Items.Add(new MyItem { Id = reader.GetValue(0).ToString(), Type = "Тренировка", Name = reader.GetValue(2).ToString(), Discriptions = reader.GetValue(4).ToString() });
                        }
                        reader.Close();
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ошибка входа " + exp.Message);
                }
            }
            if (index == 2)
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
                            ListFromDb.Items.Add(new MyItem { Id = reader.GetValue(0).ToString(), Type = "Диета", Name = reader.GetValue(1).ToString(), Discriptions = reader.GetValue(3).ToString() });
                        }
                        reader.Close();
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ошибка входа " + exp.Message);
                }
            }

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminSettings.InsertDataInDB());
        }


        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (canDelete)
            {
                if (myItem.Type == "Диета")
                {


                    try
                    {
                        ConnectToDB.Connect.Conn();
                        //create instanace of database connection
                        using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                        {
                            
                            conn.Open();
                            string sql = "DELETE FROM Diets WHERE Id = @id";
                            SqlCommand command = new SqlCommand(sql, conn);

                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Ошибка входа " + exp.Message);
                    }
                }
                else if(myItem.Type == "Тренировка")
                {
                    try
                    {
                        ConnectToDB.Connect.Conn();
                        //create instanace of database connection
                        using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                        {
                            
                            conn.Open();
                            string sql = "DELETE FROM Trainings WHERE Id=@id";
                            SqlCommand command = new SqlCommand(sql, conn);

                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Ошибка входа " + exp.Message);
                    }
                }
            }
            canDelete = false;
        }

        private void ListFromDb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                myItem = (MyItem)ListFromDb.SelectedItem;//выбираем эл по шаблону
                id = myItem.Id;
                canDelete = true;
            }catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
                NavigationService.Navigate(new AdminPanel());
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)//обновление
        {
            ListFromDb.Items.Clear();
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
                        ListFromDb.Items.Add(new MyItem { Id = reader.GetValue(0).ToString(), Type = "Тренировка", Name = reader.GetValue(2).ToString(), Discriptions = reader.GetValue(4).ToString() });
                    }
                    reader.Close();

                    sql = "SELECT * FROM Diets";
                    command = new SqlCommand(sql, conn);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListFromDb.Items.Add(new MyItem { Id = reader.GetValue(0).ToString(), Type = "Диета", Name = reader.GetValue(1).ToString(), Discriptions = reader.GetValue(3).ToString() });
                    }
                    reader.Close();
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }
    }
}
