using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using DrDDiary.Helpers;
using DrDDiary.Views;
using ReactiveUI;
using System.ComponentModel;
using System.Reactive;
using System.Xml.Linq;

namespace DrDDiary.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private MainWindow mainWindow;

    public MainWindowViewModel()
    { 
        SKbuttonClicked = ReactiveCommand.Create(SetSKLanguage);
        ENbuttonClicked = ReactiveCommand.Create(SetENLanguage);

        mainWindow = new MainWindow() { DataContext = this };
    }

    public ReactiveCommand<Unit, Unit> SKbuttonClicked { get; set; }
    public ReactiveCommand<Unit, Unit> ENbuttonClicked { get; set; }

    private void SetSKLanguage()
    {
        LanguageManager.SetLanguageResource("SK");
    }

    private void SetENLanguage()
    {
        LanguageManager.SetLanguageResource("EN");
    }

    public MainWindow GetView()
    {
        return mainWindow;
    }
}
