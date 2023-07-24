using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void MailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }
        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(LoginBox.Text, "^[a-zA-Z0-9]")&& LoginBox.Text.Length != 0)
            {/*
             * 8-15 символов, минимум одно число, большая и маленькая буква
            */
                if(LoginBox.Text.Length<5)
                {
                    LoginBox.BorderBrush = Brushes.Red;
                    label_reg.Content = "Логин должен содержать более 5 символов";
                }
                LoginBox.BorderBrush = Brushes.Red;
                label_reg.Content = "Ввод данных на кириллице недоступен";
            }
            else
            {
                LoginBox.BorderBrush = Brushes.Black;
                label_reg.Content = "";
            }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(passwordBox.Password, "^[a-zA-Z0-9]") && passwordBox.Password.Length != 0)
            {
                if (passwordBox.Password.Length < 5)
                {
                    passwordBox.BorderBrush = Brushes.Red;
                    label_reg.Content = "Пароль должен содержать более 5 символов";
                }
                passwordBox.BorderBrush = Brushes.Red;
                label_reg.Content = "Ввод данных запрещен на кириллице";
            }
            else
            {
                passwordBox.BorderBrush = Brushes.Black;
                label_reg.Content = "";
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            bool isOk = false ;
            if (!String.IsNullOrEmpty(MailBox.Text))
            {
                isOk = validateEmail(MailBox.Text);
                MailBox.BorderBrush = Brushes.Black;
            }
            else
            {
                MailBox.BorderBrush = Brushes.Red;
                label_reg.Content = "почта не прошла валидацию";
            }

            if(isOk)
            {
                try
                {
                    if (!String.IsNullOrEmpty(LoginBox.Text)|| !String.IsNullOrEmpty(passwordBox.Password) )
                    {
                        if (passwordBox.Password.Length > 5)
                        {

                            if (LoginBox.Text.Length > 5)
                            {
                                ConnectToDB.Connect.Conn();
                                //create instanace of database connection
                                using (SqlConnection conn = new SqlConnection(ConnectToDB.Connect.connString))
                                {
                                    int id = 0;
                                    bool canRegist = false;
                                    conn.Open();

                                    string sql = "SELECT *FROM Users";
                                    SqlCommand comm = new SqlCommand(sql, conn);
                                    SqlDataReader reader = comm.ExecuteReader();//объект, помогает построчно читать таблицу
                                    if (reader.HasRows) // если есть данные
                                    {
                                        while (reader.Read())
                                        {
                                            if (reader.GetValue(1).ToString() == LoginBox.Text && reader.GetValue(3).ToString() == MailBox.Text)
                                            {
                                                canRegist = false;
                                                label_reg.Content = "Пользователь уже зарегистрирован";
                                                break;
                                            }
                                            else
                                            {
                                                canRegist = true;//разрешение для регистрации
                                            }
                                            id++;
                                        }

                                    }
                                    else
                                    {
                                        canRegist = true;
                                    }
                                    reader.Close();

                                    sql = "INSERT INTO users(Login,Password,Email,RegisterDate,IsAdmin) values ( @Login , @Password , @mail , @RegisterDate , @IsAdmin)";
                                    SqlCommand command = new SqlCommand(sql, conn);
                                    if (canRegist)
                                    {
                                        command.Parameters.AddWithValue("@Login", LoginBox.Text);
                                        command.Parameters.AddWithValue("@Password", passwordBox.Password);
                                        command.Parameters.AddWithValue("@mail", MailBox.Text);
                                        command.Parameters.AddWithValue("@RegisterDate", DateTime.Now);
                                        command.Parameters.AddWithValue("@IsAdmin", 0);

                                        command.ExecuteNonQuery();
                                        InfoUser.Id = id;
                                        InfoUser.IsAdmin = 0;

                                        MainWindow main = new MainWindow();
                                        main.Show();
                                        this.Close();
                                    }

                                }
                            }else
                            {
                                LoginBox.BorderBrush = Brushes.Red;
                                label_reg.Content = "Логин должен содержать более 5 символов";
                            }
                        }else
                        {
                            passwordBox.BorderBrush = Brushes.Red;
                            label_reg.Content = "Пароль должен содержать более 5 символов";
                        }
                    }else
                    {

                        label_reg.Content = "Заполните все поля";
                       
                        LoginBox.BorderBrush= Brushes.Red;
                        passwordBox.BorderBrush = Brushes.Red;
                    }
                }catch(Exception exp)
                {
                    MessageBox.Show("Ошибка регистрации: "+exp.Message);
                }
            }
        }

        private void log_form_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }


        static bool validateEmail(string email)//подключали для этого библиотеку
        {
            if (email == null)
            {
                return false;
            }
            if (new EmailAddressAttribute().IsValid(email))
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}
