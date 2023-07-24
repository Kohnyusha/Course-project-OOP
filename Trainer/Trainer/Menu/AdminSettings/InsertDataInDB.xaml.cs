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

namespace Trainer.Menu.AdminSettings
{
    /// <summary>
    /// Логика взаимодействия для InsertDataInDB.xaml
    /// </summary>
    public partial class InsertDataInDB : Page
    {
        public InsertDataInDB()
        {
            InitializeComponent();
        }


        private void AddToDBDiets_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectToDB.Connect.Conn();
                //create instanace of database connection
                using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                {
                    conn.Open();
                    int id = 0;
                    string sql = "SELECT *FROM Diets";
                    SqlCommand comm = new SqlCommand(sql, conn);
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())
                        {

                            id++;
                        }

                    }

                    reader.Close();

                    sql = "INSERT INTO Diets(Name,Type,Discription) values(@Name , @Type , @Discriptions)";
                    SqlCommand command = new SqlCommand(sql, conn);

                    command.Parameters.AddWithValue("@Name", NameInDB.Text);
                    command.Parameters.AddWithValue("@Type", TypeInDB.Text);
                    command.Parameters.AddWithValue("@Discriptions", Discriptions.Text);

                    command.ExecuteNonQuery();


                }
                MessageBox.Show("Диета была добавлена");

                TypeInDB.Clear();
                NameInDB.Clear();
                Discriptions.Clear();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void AddToDBTreining_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ConnectToDB.Connect.Conn();
                //create instanace of database connection
                using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                {
                    conn.Open();
                    int id = 0;
                    string sql = "SELECT *FROM Trainings";
                    SqlCommand comm = new SqlCommand(sql, conn);
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())
                        {
                            id++;
                        }

                    }

                    reader.Close();

                    sql = "INSERT INTO Trainings(Type,Name,Lessons,Discription) values(@Type , @Name,@Lessons , @Discriptions)";
                    SqlCommand command = new SqlCommand(sql, conn);

                    
                    command.Parameters.AddWithValue("@Type", TypeInDB_Treining.Text);
                    command.Parameters.AddWithValue("@Name", NameInDB_Treining.Text);
                    command.Parameters.AddWithValue("@Lessons", Lessons_Treining.Text);
                    command.Parameters.AddWithValue("@Discriptions", Discriptions_Treining.Text);

                    command.ExecuteNonQuery();


                }
                MessageBox.Show("Тренировка была добавлена");

                //очищение текстбоксов
                TypeInDB_Treining.Clear();
                NameInDB_Treining.Clear();
                Discriptions_Treining.Clear();
                Lessons_Treining.Clear();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void Lessons_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
