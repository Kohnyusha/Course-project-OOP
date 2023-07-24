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

namespace Trainer.Menu.TreiningPage
{
    /// <summary>
    /// Логика взаимодействия для StartTreining.xaml
    /// </summary>
    public partial class StartTreining : Page
    {
        public StartTreining()
        {
            InitializeComponent();
            if(InfoUser.IsAdmin == 1)
            {
                like.Visibility = Visibility.Hidden;
            }
            takeInfo();

        }

        public string str;
        public string[] data;
        public bool canSub = false;
        public int idTreining;
        public void takeInfo()
        {
            for(int i=0;i<=MainTreiningPage.ListOfTreinings.Count-1;i++)
            {
                if(InfoTreining.str == MainTreiningPage.ListOfTreinings[i].Name)//ищем нужный эл соответствующий нашему стр
                {
                    idTreining = MainTreiningPage.ListOfTreinings[i].ID;//id трени в табл  тренировок
                    str = MainTreiningPage.ListOfTreinings[i].Discriptions;
                    break;
                }
            }
            data = str.Split('/');

            Random rd = new Random();
            int value = rd.Next(1,5);
            Image image = new Image();
            image.Source = new BitmapImage(new Uri($"pack://application:,,,/Resource/{value}.jpg"));
            StackImage.Children.Add(image);//загруж в stackpanel картинки

            createInfo();//подписка?
            infoFromFinishTreining();//проверка пройдено ли
        }

        public void createInfo()
        {
            for (var i = 0; i <= data.Length-1; i++) 
            {
                if (!String.IsNullOrEmpty(data[i]))
                {
                    MainStackPanel.Children.Add(new TextBlock //создание эл через код
                    {
                        Text = data[i],
                        FontSize = 25,
                        TextWrapping = TextWrapping.Wrap,
                        HorizontalAlignment = HorizontalAlignment.Left

                    }); 
                }
            }

            infoFromLikes();
        }

        public void infoFromLikes()//подписан или нет
        {
            try
            {
                ConnectToDB.Connect.Conn();
                //create instanace of database connection
                using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                {
                    conn.Open();

                    string sql = "SELECT * FROM Likes";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //сравнение id и трени с табл тренировок
                            if (InfoUser.Id == Convert.ToInt32(reader.GetValue(0)) && idTreining == Convert.ToInt32(reader.GetValue(1)))
                            {
                                canSub = false;
                                break;
                            }
                            else
                            {
                                canSub = true;
                            }
                            i++;
                        }
                    }else
                    {
                        canSub = true;
                    }
                    reader.Close();
                    if (canSub)
                    {
                        like.Content = "подписаться";
                    }
                    else
                    {
                        like.Content = "отписаться";
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }

        public void infoFromFinishTreining()//прошли треню
        {
            try
            {
                ConnectToDB.Connect.Conn();
                //create instanace of database connection
                using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                {
                    conn.Open();

                    string sql = "SELECT * FROM FinishTreining";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    int i = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (InfoUser.Id == Convert.ToInt32(reader.GetValue(0)) && idTreining == Convert.ToInt32(reader.GetValue(1)))
                            {
                                canSub = false;
                                break;
                            }
                            else
                            {
                                canSub = true;
                            }
                            i++;
                        }
                    }
                    else
                    {
                        canSub = true;
                    }
                    reader.Close();
                    if (canSub)
                    {
                        Finish.Content = "Не пройдено";
                    }
                    else
                    {
                        Finish.Content = "Пройдена";
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InfoTreining());
        }

        private void like_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ConnectToDB.Connect.Conn();
                //create instanace of database connection
                using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                {
                    string id = null;

                    conn.Open();

                    string sql = "SELECT * FROM Trainings";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (InfoTreining.str == reader.GetValue(2).ToString())//назв тренировки из листа с назв из таблицы
                        {
                            id = reader.GetValue(0).ToString();
                        }
                    }
                    reader.Close();

                   
                    if (canSub)//не подписан, то подпис
                    {
                        sql = "INSERT INTO Likes([Id_User],[Id_Like],[Type]) values (@idUser, @IdLike, @Type)";
                        command = new SqlCommand(sql, conn);

                        {
                            command.Parameters.AddWithValue("@idUser", InfoUser.Id);
                            command.Parameters.AddWithValue("@IdLike", Convert.ToInt32(id));
                            command.Parameters.AddWithValue("@Type", "Тренировка");

                            command.ExecuteNonQuery();

                            MessageBox.Show("Вы подписались на тренировку!");
                        }
                    }
                    else
                    {
                        sql = "DELETE FROM Likes WHERE Id_User = @idUser and Id_Like = @idLike";
                        command = new SqlCommand(sql, conn);

                        command.Parameters.AddWithValue("@idUser", InfoUser.Id);
                        command.Parameters.AddWithValue("@idLike", Convert.ToInt32(id));
                        command.ExecuteNonQuery();

                        MessageBox.Show("Вы отписались от тренировки!");
                    }
                }
                infoFromLikes();//запрашиваем систему проверку подписки
                
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectToDB.Connect.Conn();
                //create instanace of database connection
                using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                {
                    string id = null;

                    conn.Open();

                    string sql = "SELECT * FROM Trainings";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (InfoTreining.str == reader.GetValue(2).ToString())
                        {
                            id = reader.GetValue(0).ToString();
                        }
                    }
                    reader.Close();


                    if (canSub)
                    {
                        sql = "INSERT INTO FinishTreining([id_user],[id_treining],[date]) values (@idUser, @id_treining, @date)";
                        command = new SqlCommand(sql, conn);

                        {
                            command.Parameters.AddWithValue("@idUser", InfoUser.Id);
                            command.Parameters.AddWithValue("@id_treining", Convert.ToInt32(id));
                            command.Parameters.AddWithValue("@date", DateTime.Now);

                            command.ExecuteNonQuery();
                            MessageBox.Show("Вы прошли тренировку!");
                        }
                    }
                    else
                    {
                        sql = "DELETE FROM FinishTreining WHERE id_user = @idUser and id_treining = @id_treining";
                        command = new SqlCommand(sql, conn);

                        command.Parameters.AddWithValue("@idUser", InfoUser.Id);
                        command.Parameters.AddWithValue("@id_treining", Convert.ToInt32(id));
                        command.ExecuteNonQuery();
                        MessageBox.Show("Вы отменили прохождение тренировки!");
                    }
                }
                infoFromFinishTreining();
                
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }
    }
}
