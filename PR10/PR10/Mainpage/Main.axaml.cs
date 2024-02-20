using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Microsoft.CodeAnalysis;
using MySql.Data.MySqlClient;
using PR10.Add;
using YPISPRO41.Class2;

namespace PR10.Mainpage;

public partial class Main : Window
{
    private MySqlConnectionStringBuilder _connectionSb;
    private ObservableCollection<ПользователиКласс> ПользователиКлассы { get; set; }
    private ObservableCollection<ТоварКласс> ТоварКлассы { get; set; }
    private ObservableCollection<ЗаказыКласс> ЗаказыКлассы { get; set; }
    private ObservableCollection<Пункты_выдачиКласс> Пункты_выдачиКлассы { get; set; }
    
    public Main(int a)
    {
        Width=1100;
        Height=350;
        ТоварКлассы = new ObservableCollection<ТоварКласс>();
        ЗаказыКлассы = new ObservableCollection<ЗаказыКласс>();
        ПользователиКлассы = new ObservableCollection<ПользователиКласс>();
        Пункты_выдачиКлассы = new ObservableCollection<Пункты_выдачиКласс>();
        _connectionSb = new MySqlConnectionStringBuilder()
        {
            Server = "localhost",
            Database = "yp",
            UserID = "User",
            Password = "123456"
        };
      
        InitializeComponent();
        ShowTable();
        ShowTable2();
        ShowTable3();
        ShowTable4();
        if (a != 1)
        {
            AddProductsButton.IsVisible = false;
            AddProductsButton.IsEnabled = false;
            DelBox.IsVisible = false;
            DelProductsButton.IsVisible = false;
            DelProductsButton.IsEnabled = false;
            CheckBox.IsVisible = false;
            textdel.IsVisible = false;
        }

       
    }
   
     private void ShowTable()
    {
        using (var connection = new MySqlConnection(_connectionSb.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = " SELECT * FROM товар ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ТоварКлассы.Add(new ТоварКласс()
                        {
                          
   
    Наименование =  reader.GetString("Наименование"),
    Изображение = LoadImage("avares://PR10/Image/" + reader.GetString("Изображение") + ".jpg"),
    Стоимость  =  reader.GetInt32("Стоимость"),
    Производитель =  reader.GetInt32("Производитель"),
    Кол_на_складе = reader.GetInt32("Кол_на_складе"),
    Описание = reader.GetString("Описание")
   
                       
                        });
                    }
                }
            }
            connection.Close();
        }
        ProductsDataGrid.ItemsSource = ТоварКлассы;
    }
     public Bitmap LoadImage(string Uri)
     {
         return new Bitmap(AssetLoader.Open(new Uri(Uri)));
     }
    private void ShowTable2()
    {
        using (var connection = new MySqlConnection(_connectionSb.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = " SELECT * FROM заказы ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ЗаказыКлассы.Add(new ЗаказыКласс()
                        {
                            Номер_заказа =  reader.GetInt32("Номер_заказа"),
                            Состав_заказа  =  reader.GetString("Состав_заказа"),
                            Количество  =  reader.GetInt32("Количество"),
                            Дата_заказа =  reader.GetString("Дата_заказа"),
                            Дата_доставки =  reader.GetString("Дата_доставки"),
                            Пункт_выдачи = reader.GetInt32("Пункт_выдачи"),
                            ФИО_клиента = reader.GetInt32("ФИО_клиента"),
                            Код_для_получения =  reader.GetString("Код_для_получения"),
                            Статус_заказа = reader.GetInt32("Статус_заказа")
                       
                        });
                    }
                }
            }
            connection.Close();
        }
        OrdersDataGrid.ItemsSource = ЗаказыКлассы;
    }
    private void ShowTable3()
    {
        using (var connection = new MySqlConnection(_connectionSb.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = " SELECT * FROM пункты_выдачи ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Пункты_выдачиКлассы.Add(new  Пункты_выдачиКласс()
                        {
                            Почтовый_индекс = reader.GetInt32("Почтовый_индекс"),
                            Город = reader.GetInt32("Город"),
                            Улица = reader.GetInt32("Улица"),
                            Дом = reader.GetInt32("Дом")
                        });
                        
                    }
                }
            }
            connection.Close();
        }
        PostOfficeDataGrid.ItemsSource = Пункты_выдачиКлассы;
    }
    private void ShowTable4()
    {
        using (var connection = new MySqlConnection(_connectionSb.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = " SELECT * FROM Пользователи ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ПользователиКлассы.Add(new  ПользователиКласс()
                        {
                            Роль_сотрудника = reader.GetInt32("Роль_сотрудника"),
                            ФИО = reader.GetInt32("ФИО"),
                            Логин = reader.GetString("Логин"),
                            Пароль = reader.GetString("Пароль")
                        });
                        
                    }
                }
            }
            connection.Close();
        }
        UserDataGrid.ItemsSource = ПользователиКлассы;
    }
    

    private void AddProductsButton_OnClick(object? sender, RoutedEventArgs e)
    {
        AddProducts add = new AddProducts();
        add.Show();
    }

    private void DelProductsButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (CheckBox.IsChecked == true)
        {
           
            var remove = ProductsDataGrid.SelectedItem as ТоварКласс;
            string del = DelBox.Text;
            using (var cnn = new MySqlConnection(_connectionSb.ConnectionString))
            {
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Товар where ID = " + del;
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }

                ТоварКлассы.Remove(remove);
                cnn.Close();
            }

            ProductsDataGrid.DataContext = ТоварКлассы;
            CheckBox.IsChecked = false;
        }
        
    }


    private void SerachBoxOrders_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var serach = new List<ТоварКласс>(ТоварКлассы);
        serach = serach.Where(x => x.Наименование.ToString().Contains(serach.ToString())).ToList();
        if (SerachBoxProduct.Text == "")
        {
             ProductsDataGrid.SelectedItem = ТоварКлассы;
        }
    }

    private void Exit_OnClick(object? sender, RoutedEventArgs e)
    {
        new LoginUser().Show();
        this.Close();
    }
}