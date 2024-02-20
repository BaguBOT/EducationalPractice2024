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
using MySql.Data.MySqlClient;
using YPISPRO41.Class2;

namespace PR10;

public partial class MainGuest : Window
{
    private MySqlConnectionStringBuilder _connectionSb;
    private ObservableCollection<ТоварКласс> ТоварКлассы { get; set; }
    private ObservableCollection<ЗаказыКласс> ЗаказыКлассы { get; set; }
    private ObservableCollection<Пункты_выдачиКласс> Пункты_выдачиКлассы { get; set; }
   public MainGuest()
    {
        Width=1000;
        Height=350;
        ТоварКлассы = new ObservableCollection<ТоварКласс>();
        ЗаказыКлассы = new ObservableCollection<ЗаказыКласс>();
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
                            
    Изображение = LoadImage("avares://PR10/Image/" + reader.GetString("Изображение") + ".jpg"),
    Наименование =  reader.GetString("Наименование"),
    Стоимость  =  reader.GetInt32("Стоимость"),
    Производитель =  reader.GetInt32("Производитель"),
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
    private void SerachBoxProducts_OnTextChanging(object? sender, TextChangingEventArgs e)
    {
        var serach = new List<ТоварКласс>(ТоварКлассы);
        serach = serach.Where(x => x.Наименование.ToString().Contains(serach.ToString())).ToList();
        if (SerachBoxPostOffice.Text == "")
        {
             ProductsDataGrid.SelectedItem = ТоварКлассы;
        }
    }
    private void SerachBoxOrders_OnTextChanging(object? sender, TextChangingEventArgs e)
    {
        var serach = new List<ЗаказыКласс>(ЗаказыКлассы);
        serach = serach.Where(x => x.Номер_заказа.ToString().Contains(serach.ToString())).ToList();
        if (SerachBoxPostOffice.Text == "")
        {
         OrdersDataGrid.SelectedItem = ЗаказыКлассы;
        }
    }
    private void SerachBoxPostOffice_OnTextChanging(object? sender, TextChangingEventArgs e)
    {
        var serach = new List<Пункты_выдачиКласс>(Пункты_выдачиКлассы);
        serach = serach.Where(x => x.Почтовый_индекс.ToString().Contains(serach.ToString())).ToList();
        if (SerachBoxPostOffice.Text == "")
        {
             PostOfficeDataGrid.SelectedItem = Пункты_выдачиКлассы;
        }
    }

    private void Exit_OnClick(object? sender, RoutedEventArgs e)
    {
        new LoginUser().Show();
        this.Close();
    }
}
