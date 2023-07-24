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
using System.Windows.Shapes;

namespace Trainer.Login_Register
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(LoginBox.Text) && !String.IsNullOrEmpty(passwordBox.Password))//пустая ли строка
                {
                    ConnectToDB.Connect.Conn();//путь к файлу с бд
                    //create instanace of database connection
                    using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                    {
                        int id = 0;
                        bool canEntry = false;
                        conn.Open();
                        string sql = "SELECT * FROM Users";
                        SqlCommand command = new SqlCommand(sql, conn);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.GetValue(1).ToString() == LoginBox.Text && reader.GetValue(2).ToString() == passwordBox.Password)
                            {
                                InfoUser.Id = Convert.ToInt32(reader.GetValue(0));
                                InfoUser.IsAdmin = Convert.ToInt32(reader.GetValue(5));
                                canEntry = true;
                                MainWindow main = new MainWindow();
                                main.Show();
                                this.Close();
                                break;
                            }
                            else
                            {
                                canEntry = false;
                            }
                        }
                        if (!canEntry)
                        {
                            label_error.Content = "Пользователя нет в системе";
                        }
                    }
                }
                else
                {
                    label_error.Content = "Заполните все поля";
                    LoginBox.Foreground = Brushes.Red;
                    passwordBox.Foreground = Brushes.Red;
                }

                }catch(Exception exp)
            {
                MessageBox.Show("Ошибка входа "+exp.Message);
            }
        }

        private void reg_form_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(LoginBox.Text, "^[a-zA-Z0-9]") && LoginBox.Text.Length != 0)
            {
                LoginBox.Foreground = Brushes.Red;
                label_error.Content = "Запрещена кириллица";
            }
            else
            {
                LoginBox.Foreground = Brushes.Black;
                label_error.Content = "";
            }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(passwordBox.Password, "^[a-zA-Z0-9]") && passwordBox.Password.Length != 0)
            {
                passwordBox.Foreground = Brushes.Red;
                label_error.Content = "Запрещена кириллица";
            }
            else
            {
                passwordBox.Foreground = Brushes.Black;
                label_error.Content = "";
            }
        }
    }
}
