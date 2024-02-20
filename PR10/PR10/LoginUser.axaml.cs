using System;
using System.Drawing;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using PR10.Mainpage;
using Bitmap = Avalonia.Media.Imaging.Bitmap;
using Image = Avalonia.Controls.Image;

namespace PR10;

public partial class LoginUser : Window
{
    private string _connectserv = "server=localhost;uid=User;" +
                                  "database=yp;" +
                                  "password=123456;";
    private int iNumber;
    public int admin;
    public string name;
    public LoginUser()
    {
        Width=300;
        Height=400;
        Random oRandom = new Random(); 
        iNumber = oRandom.Next(1000, 9999);
        InitializeComponent();
    }
    
   
    private void Guest_OnClick(object? sender, RoutedEventArgs e)
    {
        new MainGuest().Show();
        this.Close();
    }

    private void Login_OnClick(object? sender, RoutedEventArgs e)
    {
        string login = LoginBox.Text;
        string password = PasswordBox.Text;
        if (AdminBox.IsChecked == true)
        {
            admin = 1;
        }
        else
        {
            admin = 0;
        }
        try
        {
            MySqlConnection sqlCon = new MySqlConnection(_connectserv);
            if (sqlCon.State == System.Data.ConnectionState.Closed)
                sqlCon.Open();
        
           
            string que = "SELECT * FROM пользователи WHERE Логин=@Login AND Пароль=@Password";
            MySqlCommand sqlCmd = new MySqlCommand(que, sqlCon);
            sqlCmd.CommandType = System.Data.CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@Login", login);
            sqlCmd.Parameters.AddWithValue("@Password", password);
            
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            if (count  >= 1 && count<= 10 )
            {
                
                Main mw = new Main(admin);
                mw.Show();
                this.Close();
            }
            else
            {
                TextError.Text = "ОШИБКА Вы робот?";
               
                
                
                Textbox.Text = Convert.ToString(iNumber);
                Textbox.IsVisible = true;
                Check.IsVisible = true;
                Update.IsVisible = true;
                
                BoxCheck.IsVisible = true;
                LoginButton.IsEnabled = false;
            }
        }
        catch (Exception exception)
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка",
                "Учетной записи не существует, проверьте правильность Логина И Пароля", 
                ButtonEnum.OkCancel);
            Console.WriteLine(exception);
            throw;
        }
    }

    private void UpdateCAPTCHA_OnClick(object? sender, RoutedEventArgs e)
    {
        Random oRandom = new Random(); 
        iNumber = oRandom.Next(1000, 9999);
        Textbox.Text = Convert.ToString(iNumber);
        
    }

    private void Check_OnClick(object? sender, RoutedEventArgs e)
    {
      int check =  Convert.ToInt32(BoxCheck.Text);
        if (iNumber == check )
        {
            LoginButton.IsEnabled = true;
            Textbox.IsVisible = false;
            TextError.IsVisible = false;
            Check.IsVisible = false;
            Update.IsVisible = false;
           
            BoxCheck.IsVisible = false;
            Random oRandom = new Random(); 
            iNumber = oRandom.Next(1000, 9999);
            Textbox.Text = Convert.ToString(iNumber);
        }
        else
        {
            Random oRandom = new Random(); 
            iNumber = oRandom.Next(1000, 9999);
            Textbox.Text = Convert.ToString(iNumber);
           
        }
    }
   
}