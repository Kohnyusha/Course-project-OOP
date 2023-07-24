using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Helpers;
using LiveCharts.Wpf;

namespace Trainer.Menu.User
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
       

        public List<string> days = new List<string>();
        public List<string> uniqueList = new List<string>();//лист, пошедший сортировку по датам (удаление диблей)
        ChartValues<int> value = new ChartValues<int>();//сколько тренировок в день прошел
        public UserPage()
        {
            InitializeComponent();

            LoadFromDB();
            CreateGraphis();

            statistics.LegendLocation = LegendLocation.Bottom;
        }

        public void LoadFromDB()//загрузка из бд
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
                   
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (InfoUser.Id == Convert.ToInt32(reader.GetValue(0)))
                            {
                                days.Add(reader.GetValue(2).ToString());
                            }
                        }
                        reader.Close();
                    }

                    // удаление дубликатов, занесение в лист uniqueList
                    uniqueList = days.Distinct().ToList();

                    //ищем кол-во пройденных тренировок
                    for (int i = 0; i<=uniqueList.Count-1;i++)
                    {
                        sql = "SELECT * FROM FinishTreining";
                        command = new SqlCommand(sql, conn);
                        reader = command.ExecuteReader();
                        int k = 0;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (uniqueList[i] == reader.GetValue(2).ToString() && InfoUser.Id == Convert.ToInt32(reader.GetValue(0)))
                                {
                                    k++;
                                }

                            }
                            reader.Close();
                            value.Add(k);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка входа " + exp.Message);
            }
        }

        public void CreateGraphis()
        {
            SeriesCollection seriesViews = new SeriesCollection();
            statistics.AxisX.Clear();
            statistics.AxisX.Add(new Axis()
            {
                Title = "Даты",
                FontSize=15,
                Labels = uniqueList//даты без дубликатов, сразу весь список
            });

            //statistics.AxisY.Add(new Axis()
            //{ 
                
            //});


            LineSeries line = new LineSeries();//использование линий для отрисовки
            line.Title = "Количество тренировок в день";
            line.Values = value;
            
            seriesViews.Add(line);//доб в коллекцию построенных линий

            statistics.Series = seriesViews;//доб в саму диаграмму

        }
    }
}





