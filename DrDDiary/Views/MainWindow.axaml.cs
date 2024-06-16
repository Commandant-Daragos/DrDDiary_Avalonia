using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using DrDDiary.Helper;
using DrDDiary.Helpers;
using DrDDiary.Serializer;
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

        Character_Button.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGECLICKED)) };

        SetLanguageButtons();
        SetDiaryPlayerButtonsToDefault();

    }

    private void SK_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MusicPlayer.PlayClickSound();
        SK_Button.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGECLICKED)) };
        EN_Button.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGENOTCLICKED)) };
    }

    private void EN_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MusicPlayer.PlayClickSound();
        SK_Button.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGENOTCLICKED)) };
        EN_Button.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGECLICKED)) };
    }

    private void DiaryPlayer_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MusicPlayer.PlayClickSound();
        SetDiaryPlayerButtonsToDefault();
        ((Button)sender).Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGECLICKED)) };
    }

    private void Button_PointerEntered(object? sender, Avalonia.Input.PointerEventArgs e)
    {
        MusicPlayer.PlayHoverSound();
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

    private void SetDiaryPlayerButtonsToDefault()
    {
        Character_Button.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGENOTCLICKED)) };
        Inventory_Button.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGENOTCLICKED)) };
        Skill_Button.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGENOTCLICKED)) };
        Lore_Button.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGENOTCLICKED)) };
        Notes_Button.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGENOTCLICKED)) };
    }

    private void SetLanguageButtons()
    {
        SK_Button.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGECLICKED)) };
        EN_Button.Content = new Image { Source = new Bitmap(Path.Combine(Directory.GetCurrentDirectory(), IMAGENOTCLICKED)) };
    }

    private async void Window_Closing(object? sender, Avalonia.Controls.WindowClosingEventArgs e)
    {
        var mainWindowViewModel = (MainWindowViewModel)DataContext;
        await PlayerStorage.SavePlayerAsync(mainWindowViewModel.Player);
    }
}
