using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Trainer.Menu.DietsInfo
{
    /// <summary>
    /// Логика взаимодействия для DietsStart.xaml
    /// </summary>
    public partial class DietsStart : Page
    {
        public DietsStart()
        {
            InitializeComponent();
            if(InfoUser.IsAdmin==1)
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
            for (int i = 0; i <= MainDiets.listOfDiets.Count - 1; i++)
            {
                if (DietsInfo.str == MainDiets.listOfDiets[i].Name)
                {
                    idTreining = MainDiets.listOfDiets[i].ID;
                    str = MainDiets.listOfDiets[i].Discriptions;
                    break;
                }
            }
            data = str.Split('/');
            Random rd = new Random();
            int value = rd.Next(1, 5);
            Image image = new Image();
            image.Source = new BitmapImage(new Uri($"pack://application:,,,/Resource/eat{value}.jpg"));
            StackImage.Children.Add(image);
            createInfo();
        }

        public void createInfo()
        {
            for (var i = 0; i <= data.Length - 1; i++)
            {
                if (!String.IsNullOrEmpty(data[i]))
                {
                    MainStackPanel.Children.Add(new TextBlock
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


        public void infoFromLikes()
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
                        reader.Close();
                    }
                    else
                    {
                        canSub = true;
                    }
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

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DietsInfo());
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

                        string sql = "SELECT * FROM Diets";
                        SqlCommand command = new SqlCommand(sql, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (DietsInfo.str == reader.GetValue(1).ToString())
                                {
                                    id = reader.GetValue(0).ToString();
                                }
                            }
                            reader.Close();
                        }
                        if (canSub)
                        {
                            sql = "INSERT INTO Likes([Id_User],[Id_Like],[Type]) values (@idUser, @IdLike, @Type)";
                            command = new SqlCommand(sql, conn);

                            {
                                command.Parameters.AddWithValue("@idUser", InfoUser.Id);
                                command.Parameters.AddWithValue("@IdLike", Convert.ToInt32(id));
                                command.Parameters.AddWithValue("@Type", "Диета");

                                command.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            sql = "DELETE FROM Likes WHERE Id_User = @idUser and Id_Like = @idLike";
                            command = new SqlCommand(sql, conn);

                            command.Parameters.AddWithValue("@idUser", InfoUser.Id);
                            command.Parameters.AddWithValue("@idLike", Convert.ToInt32(id));
                            command.ExecuteNonQuery();
                        }
                    }
                    infoFromLikes();
                    MessageBox.Show("Вы подписались на диету!");
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ошибка входа " + exp.Message);
                }
            
        }
    }
}
