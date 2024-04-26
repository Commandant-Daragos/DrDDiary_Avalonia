using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using DrDDiary.Helpers;
using DrDDiary.Views;
using ReactiveUI;
using System;
using System.ComponentModel;
using System.Reactive;
using System.Xml.Linq;

namespace DrDDiary.ViewModels;

public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    private MainWindow mainWindow;

    public event PropertyChangedEventHandler? PropertyChanged;
    //public event EventHandler LanguageChanged;

    /// <summary>
    /// Visibility for StackPanel containing diary main buttons buttons.
    /// </summary>
    private bool _visibility;
    public bool Visibility
    {
        get { return _visibility; }

        set
        {
            _visibility = value;
            OnPropertyChanged(nameof(Visibility));
        }
    }

    public MainWindowViewModel()
    {
        SKbuttonClicked = ReactiveCommand.Create(SetSKLanguage);
        ENbuttonClicked = ReactiveCommand.Create(SetENLanguage);

        NewCharButtonClicked = ReactiveCommand.Create(NewCharacter);
        LoadCharButtonClicked = ReactiveCommand.Create(LoadCharacter);

        CharacterScreenButtonClicked = ReactiveCommand.Create(CharacterScreen);
        InventoryScreenButtonClicked = ReactiveCommand.Create(InventoryScreen);
        SkillScreenButtonClicked = ReactiveCommand.Create(SkillScreen);
        LoreScreenButtonClicked = ReactiveCommand.Create(LoreScreen);
        NotesScreenButtonClicked = ReactiveCommand.Create(NotesScreen);

        Visibility = false;

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

    /// <summary>
    /// Language buttons
    /// </summary>
    public ReactiveCommand<Unit, Unit> SKbuttonClicked { get; set; }
    public ReactiveCommand<Unit, Unit> ENbuttonClicked { get; set; }

    /// <summary>
    /// Opening buttons
    /// </summary>
    public ReactiveCommand<Unit, Unit> NewCharButtonClicked { get; set; }
    public ReactiveCommand<Unit, Unit> LoadCharButtonClicked { get; set; }

    /// <summary>
    /// Diary Player buttons
    /// </summary>
    public ReactiveCommand<Unit, Unit> CharacterScreenButtonClicked { get; set; }
    public ReactiveCommand<Unit, Unit> InventoryScreenButtonClicked { get; set; }
    public ReactiveCommand<Unit, Unit> SkillScreenButtonClicked { get; set; }
    public ReactiveCommand<Unit, Unit> LoreScreenButtonClicked { get; set; }
    public ReactiveCommand<Unit, Unit> NotesScreenButtonClicked { get; set; }

    /// <summary>
    /// Language buttons
    /// </summary>
    private void SetSKLanguage()
    {
        LanguageManager.SetLanguageResource("SK");
    }

    private void SetENLanguage()
    {
        LanguageManager.SetLanguageResource("EN");
    }
    /// <summary>
    /// Opening buttons
    /// </summary>
    private void NewCharacter()
    {
        WorkflowManager.CreateViewModels();
        WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("CharacterUC"));
        Visibility = true;
        //LanguageChanged?.Invoke(this, EventArgs.Empty);
    }

    private void LoadCharacter()
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Diary Player buttons
    /// </summary>
    private void CharacterScreen()
    {
        WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("CharacterUC"));
    }
    private void InventoryScreen()
    {
        WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("InventoryUC"));
    }
    private void SkillScreen()
    {
        WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("SkillUC"));
    }
    private void LoreScreen()
    {
        WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("LoreUC"));
    }
    private void NotesScreen()
    {
        WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("NotesUC"));
    }
    /// <summary>
    /// Class functionality
    /// </summary>
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
