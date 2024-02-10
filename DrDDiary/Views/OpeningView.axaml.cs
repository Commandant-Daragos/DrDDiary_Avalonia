using Avalonia.Controls;
using Avalonia.Media.Imaging;
using DrDDiary.Helper;
using DrDDiary.Helpers;
using System;

namespace DrDDiary.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void Button_PointerEntered(object? sender, Avalonia.Input.PointerEventArgs e)
    {
        MusicPlayer.Play();
        if (((Button)sender).Name == "newButton")
        {
            nameOfButtonLabel.Content = LanguageManager.GetString("btnNew");
        }
        else
        {
            nameOfButtonLabel.Content = LanguageManager.GetString("btnLoad");
        }
    }

    private void Button_PointerExited(object? sender, Avalonia.Input.PointerEventArgs e)
    {
        nameOfButtonLabel.Content = string.Empty;
    }
}
