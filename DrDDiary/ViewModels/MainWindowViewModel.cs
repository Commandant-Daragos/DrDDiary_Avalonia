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

public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    private MainWindow mainWindow;

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainWindowViewModel()
    {
        SKbuttonClicked = ReactiveCommand.Create(SetSKLanguage);
        ENbuttonClicked = ReactiveCommand.Create(SetENLanguage);

        mainWindow = new MainWindow() { DataContext = this };
    }

    public UserControl CurrentView
    {
        get { return _currentView; }

        set
        {
            _currentView = value;
            OnPropertyChanged(nameof(CurrentView));
        }
    }

    private UserControl _currentView = WorkflowManager.GetView("MainUC");

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

    public void SetCurrentView(UserControl uc)
    {
        CurrentView = uc;
    }

    private void OnPropertyChanged(string propName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    public MainWindow GetMainWindow()
    {
        return mainWindow;
    }
}
