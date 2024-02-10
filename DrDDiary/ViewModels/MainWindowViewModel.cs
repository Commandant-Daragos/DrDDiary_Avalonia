using Avalonia.Controls;
using Avalonia.Media;
using DrDDiary.Helpers;
using DrDDiary.Views;
using ReactiveUI;
using System.ComponentModel;
using System.Reactive;
using System.Xml.Linq;

namespace DrDDiary.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    MainWindow mainWindow;

    public MainWindowViewModel() 
    {
        mainWindow = new MainWindow();

        SKbuttonClicked = ReactiveCommand.Create(SetSKLanguage);
        ENbuttonClicked = ReactiveCommand.Create(SetENLanguage);
    }

    public ReactiveCommand<Unit, Unit> SKbuttonClicked { get; set; }
    public ReactiveCommand<Unit, Unit> ENbuttonClicked { get; set; }

    private void SetSKLanguage()
    {
        LanguageManager.SetLanguageResource("SK");
        //mainWindow.FindControl<Button>("SK").Foreground = new SolidColorBrush(Colors.Red);
        //mainWindow.FindControl<Button>("EN").Foreground = new SolidColorBrush(Colors.White);
    }

    private void SetENLanguage()
    {
        LanguageManager.SetLanguageResource("EN");
        //mainWindow.FindControl<Button>("SK").Foreground = new SolidColorBrush(Colors.White);
        //mainWindow.FindControl<Button>("EN").Foreground = new SolidColorBrush(Colors.Red);
    }
}
