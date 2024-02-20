using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace PR10.Add;

public partial class AddUser : Window
{
    public AddUser()
    {
        Width=700;
        Height=100;
        InitializeComponent();
    }

    private void AddUserButton_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    private void CancelButton_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}