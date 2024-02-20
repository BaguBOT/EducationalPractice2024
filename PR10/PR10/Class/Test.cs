using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.JavaScript;
using MySql.Data.MySqlClient;

namespace YPISPRO41.Class2;
public class ТоварКлассы1
{
    public int ID { get; set; }
    public string Аритикул { get; set; }
    public string Наименование { get; set; }
    public int Единица_измерения { get; set; }
    public int Стоимость { get; set; }
    public int РМВС { get; set; }
    public int Производитель { get; set; }
    public int Поставщик { get; set; }
    public int Категория_товара { get; set; }
    public int Действующая_скидка { get; set; }
    public int Кол_на_складе { get; set; }
    public string Описание { get; set; }
    
}
public class Test
{
    private string _connectserv = "server=localhost;uid=User;" +
                                  "database=yp;" +
                                  "password=123456;";
    private int iNumber;
    private bool CheckCPCHA;
    public bool TestCAPCHA(  int check)
    { 
        bool result = false;
      
        Random oRandom = new Random();
        iNumber = oRandom.Next(1000, 9999);
        if (iNumber == check)
        {
            result = true;
            
        }
        return result;
    }

    public bool CheckSize(int height, int width)
    {
        bool result = false;
        if (height == 550 && width == 450)
        {
            result = true;
        }

        return result;
    }
    
    public bool ShowTable()
    {
        bool result = false;
        using (var connection = new MySqlConnection(_connectserv))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = " SELECT * FROM товар ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = true;
                    }
                }
            }
            connection.Close();
        }
        return result;
    }
      private ObservableCollection<ТоварКлассы1> ТоварКлассы1 { get; set; }
     public bool AddProducts(int num1, int num2,int num3,int num4,int num5,int num6,int num7,int num8,
         string vales1,string vales2,string vales3)
    {
        bool result = true;
    
        using (var cnn = new MySqlConnection(_connectserv))
        {
            ТоварКлассы1 = new ObservableCollection<ТоварКлассы1>();
            cnn.Open();
            using (var cmd = cnn.CreateCommand())
            {
                cmd.CommandText =
                    " INSERT INTO товар ( Аритикул, Наименование, Единица_измерения, Стоимость, РМВС, Производитель, Поставщик, Категория_товара,Действующая_скидка, Кол_на_складе, Описание, Изображение)  " +
                    " VALUES ('"  + vales1 +
                    " ',' " + vales2 +
                    " ', " + Convert.ToInt32(num1) +
                    " , " + Convert.ToInt32(num2) +
                    " , " + Convert.ToInt32(num3) +
                    " , " + Convert.ToInt32(num4) +
                    " , " + Convert.ToInt32(num5) +
                    " , " + Convert.ToInt32(num6) +
                    " , " + Convert.ToInt32(num7) +
                    " , " + Convert.ToInt32(num8) +
                    " ,' " + vales3 + "')";
                try
                {
                    cmd.ExecuteNonQuery();
                    ТоварКлассы1.Add(new ТоварКлассы1()
                    {
                        Аритикул = vales1,
                        Наименование = vales2,
                        Единица_измерения = Convert.ToInt32(num1),
                        Стоимость = Convert.ToInt32(num2),
                        РМВС = Convert.ToInt32(num3),
                        Производитель = Convert.ToInt32(num4),
                        Поставщик = Convert.ToInt32(num5),
                        Категория_товара = Convert.ToInt32(num6),
                        Действующая_скидка = Convert.ToInt32(num7),
                        Кол_на_складе =Convert.ToInt32(num8),
                        Описание = vales3,
                        });
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
            cnn.Close();
        }
        return result;
    }
}




