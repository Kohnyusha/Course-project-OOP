using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Trainer.Menu.TreiningPage
{
    /// <summary>
    /// Логика взаимодействия для InfoTreining.xaml
    /// </summary>
    partial class InfoTreining : Page
    {
        public static string str;
        public InfoTreining()//заполнение листа назв тренировок
        {
            InitializeComponent();
            ListView.Items.Clear();//очищение списка
            addTreining();
            titleOfTreining.Text = InfoUser.title;
        }

        

        private void back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainTreiningPage());
        }

        public void addTreining()
        {
            
            for(int i=0;i<=MainTreiningPage.ListOfTreinings.Count-1;i++)
            {
                ListView.Items.Add(MainTreiningPage.ListOfTreinings[i].Name);
            }    
        }



        private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(!String.IsNullOrEmpty(str))//выбрали ли мы тренировку
            {
                NavigationService.Navigate(new StartTreining());
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //стр - имя трени
            //получаем имя из ListView этой стр
            str = (string)ListView.SelectedItem;
        }

        private void FindTextBox_TextChanged(object sender, TextChangedEventArgs e)//поиск
        {
            ListView.Items.Clear();//очищаем лист, чтобы данные не дублировались
            MainTreiningPage.ListOfTreinings.Clear();
           
            if (!String.IsNullOrEmpty(FindTextBox.Text))
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
                            if (reader.GetValue(1).ToString() == InfoUser.title &&  reader.GetValue(2).ToString().ToLower().StartsWith(FindTextBox.Text.ToLower()))
                            {
                                MainTreiningPage.ListOfTreinings.Add(new ListOfTreinings(reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), Convert.ToInt32(reader.GetValue(0))));
                                //загружаем данные в список на предыдущей стр
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
            }else
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
                            if (reader.GetValue(1).ToString() == InfoUser.title)
                            {
                                MainTreiningPage.ListOfTreinings.Add(new ListOfTreinings(reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), Convert.ToInt32(reader.GetValue(0))));
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
