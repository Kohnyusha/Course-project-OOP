using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Trainer.Menu
{
    /// <summary>
    /// Логика взаимодействия для Like.xaml
    /// </summary>
    public partial class Like : Page
    {
        public static List<Likes> listOflikes = new List<Likes>();
        public static List<string> id_likes = new List<string>();
        public static List<string> type = new List<string>();
        bool likeSelect = false;
        
        InfoLikes Infolike;
        public Like()
        {
            InitializeComponent();
            likeSelect = false;

            listOflikes.Clear();
            listOfLikes.Items.Clear();
            type.Clear();
            id_likes.Clear();

            UpdateList();
        }

        private void UpdateList()
        {
            try
            {
                //очистка
                listOflikes.Clear();//список всех данных из таблицы лайков
                listOfLikes.Items.Clear();//очиста листвью
                type.Clear();//тип - треня или диеат?
                id_likes.Clear();//ид трени или диеты которая была лайкнута

                ConnectToDB.Connect.Conn();
                //create instanace of database connection
                using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM Likes";
                    SqlCommand command = new SqlCommand(sql, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())
                        {
                            if (InfoUser.Id.ToString() == reader.GetValue(0).ToString())
                            {
                                id_likes.Add(reader.GetValue(1).ToString());
                                type.Add(reader.GetValue(2).ToString());

                                listOflikes.Add(new Likes(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString()));
                            }
                        }
                        reader.Close();

                        for (int k = 0; k < type.Count; k++)
                        {
                            if (type[k] == "Тренировка")
                            {
                                sql = "SELECT * FROM Trainings";
                                command = new SqlCommand(sql, conn);
                                reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    if (id_likes[k] == reader.GetValue(0).ToString())
                                    {
                                        //string id,string name, string type, string discriptions,string typeDB
                                        listOfLikes.Items.Add(new InfoLikes(reader.GetValue(0).ToString(), reader.GetValue(2).ToString(), reader.GetValue(1).ToString(), reader.GetValue(4).ToString(), "Тренировка"));
                                    }
                                }
                                reader.Close();
                            }
                            else if (type[k] == "Диета")
                            {
                                sql = "SELECT * FROM Diets";
                                command = new SqlCommand(sql, conn);
                                reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    if (id_likes[k] == reader.GetValue(0).ToString())
                                    {
                                        // string id,string name, string type, string discriptions,string typeDB
                                        listOfLikes.Items.Add(new InfoLikes(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), "Диета"));
                                    }
                                }
                                reader.Close();
                            }
                        }
                    }
                    
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }

        private void Dislake_Click(object sender, RoutedEventArgs e)
        {


            if (likeSelect)
            {
                for (int i=0; i<= listOfLikes.Items.Count-1;i++)
                {
                    try
                    {
                        ConnectToDB.Connect.Conn();
                        //create instanace of database connection
                        using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                        {
                            conn.Open();
                            
                            if(Infolike.Id == listOflikes[i].ID_LIKE && Infolike.TypeDB == listOflikes[i].TYPE)
                            {
                                string sql = "DELETE FROM Likes WHERE Id_User = @idUser and Id_Like = @idLike";
                                SqlCommand command = new SqlCommand(sql, conn);

                                command.Parameters.AddWithValue("@idUser", listOflikes[i].ID_USER);
                                command.Parameters.AddWithValue("@idLike", listOflikes[i].ID_LIKE);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Ошибка: " + exp.Message);
                    }
                }

                listOflikes.Clear();
                listOfLikes.Items.Clear();
                type.Clear();
                id_likes.Clear();

                UpdateList();
            }
            
        }

        private void ListOfLikes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Infolike = (InfoLikes)listOfLikes.SelectedItem;
            likeSelect = true;
        }
    }
}
