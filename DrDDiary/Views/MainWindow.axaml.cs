using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using DrDDiary.ViewModels;
using System;
using System.IO;

namespace DrDDiary.Views;

public partial class MainWindow : Window
{
    private const string IMAGENOTCLICKED = "Assets/Images/Buttons/dragon_generic_button_not_clicked.png";
    private const string IMAGECLICKED = "Assets/Images/Buttons/dragon_generic_button_clicked.png";

    public MainWindow()
    {
        InitializeComponent();

        SK_Button.Content = new Image { Source = new Bitmap(IMAGENOTCLICKED) };
        EN_Button.Content = new Image { Source = new Bitmap(IMAGENOTCLICKED) };
    }

    private void SK_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SK_Button.Content = new Image { Source = new Bitmap(IMAGECLICKED) };
        EN_Button.Content = new Image { Source = new Bitmap(IMAGENOTCLICKED) };
    }

    private void EN_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SK_Button.Content = new Image { Source = new Bitmap(IMAGENOTCLICKED) };
        EN_Button.Content = new Image { Source = new Bitmap(IMAGECLICKED) };
    }
}
