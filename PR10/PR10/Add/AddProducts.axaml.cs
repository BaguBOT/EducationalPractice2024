using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using MySql.Data.MySqlClient;
using YPISPRO41.Class2;

namespace PR10.Add;

public partial class AddProducts : Window
{
    private MySqlConnectionStringBuilder _connectionSb;
    private ObservableCollection<ТоварКласс> ТоварКлассы { get; set; }
    public AddProducts()
    {
        Width=1000;
        Height=200;
        ТоварКлассы = new ObservableCollection<ТоварКласс>();
        InitializeComponent();
        _connectionSb = new MySqlConnectionStringBuilder()
        {
            Server = "localhost",
            Database = "yp",
            UserID = "User",
            Password = "123456"
        };
    }
    private void AddProductsButton_OnClick(object? sender, RoutedEventArgs e)
    {
        using (var cnn = new MySqlConnection(_connectionSb.ConnectionString))
        {
            cnn.Open();
            using (var cmd = cnn.CreateCommand())
            {
                cmd.CommandText =
                    " INSERT INTO товар ( Аритикул, Наименование, Единица_измерения, Стоимость, РМВС, Производитель, Поставщик, Категория_товара,Действующая_скидка, Кол_на_складе, Описание, Изображение)  " +
                    " VALUES ('"  + ArrhythmiaBox.Text +
                    " ',' " + NameBox.Text +
                    " ', " + Convert.ToInt32(UnitOfMeasurementBox.Text) +
                    " , " + Convert.ToInt32(CostBox.Text) +
                    " , " + Convert.ToInt32(RMVSBox.Text) +
                    " , " + Convert.ToInt32(ManuFacturerBox.Text) +
                    " , " + Convert.ToInt32(SupplierBox.Text) +
                    " , " + Convert.ToInt32(ProductCategoryBox.Text) +
                    " , " + Convert.ToInt32(CurrentDiscountBox.Text) +
                    " , " + Convert.ToInt32(QuantityInStockBox.Text) +
                    " ,' " + DescriptionBox.Text + "')";
                try
                {
                    cmd.ExecuteNonQuery();
                    ТоварКлассы.Add(new ТоварКласс()
                    {
                        Аритикул = ArrhythmiaBox.Text,
                        Наименование = NameBox.Text,
                        Единица_измерения = Convert.ToInt32(UnitOfMeasurementBox.Text),
                        Стоимость = Convert.ToInt32(CostBox.Text),
                        РМВС = Convert.ToInt32(RMVSBox.Text),
                        Производитель = Convert.ToInt32(ManuFacturerBox.Text),
                        Поставщик = Convert.ToInt32(SupplierBox.Text),
                        Категория_товара = Convert.ToInt32(ProductCategoryBox.Text),
                        Действующая_скидка = Convert.ToInt32(CurrentDiscountBox.Text),
                        Кол_на_складе =Convert.ToInt32(QuantityInStockBox.Text),
                        Описание = DescriptionBox.Text,
                        });
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
            cnn.Close();
        }
        this.Close();
    }
   
    private void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
       this.Close();
    }
}