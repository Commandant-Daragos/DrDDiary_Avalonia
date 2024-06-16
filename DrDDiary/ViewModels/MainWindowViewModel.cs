using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using DrDDiary.Helpers;
using DrDDiary.Models.PlayerModel;
using DrDDiary.Serializer;
using DrDDiary.Views;
using Microsoft.Extensions.DependencyInjection;
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
    //private IServiceProvider _serviceProvider;
    //private readonly MainViewModel _mainViewModel;
    //public event EventHandler LanguageChanged;
    private CharacterViewModel _characterViewModel;
    private InventoryViewModel _inventoryViewModel;
    private SkillViewModel _skillViewModel;
    private LoreViewModel _loreViewModel;
    private NotesViewModel _notesViewModel;

    private Player _player;
    public Player Player
    {
        get => _player;
        set => _player = value;
    }



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

    public MainWindowViewModel(MainViewModel mainViewModel, CharacterViewModel cVM, InventoryViewModel iVM, SkillViewModel sVM, LoreViewModel lVM, NotesViewModel nVM)
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

        //_serviceProvider = serviceProvider;
        CurrentView = mainViewModel.GetView();//_serviceProvider.GetService<MainViewModel>().GetView();

        _characterViewModel = cVM;
        _inventoryViewModel = iVM;
        _skillViewModel = sVM;
        _loreViewModel = lVM;
        _notesViewModel = nVM;
    }
    private UserControl _currentView;
    public UserControl CurrentView
    {
        get { return _currentView; }

        set
        {
            _currentView = value;
            OnPropertyChanged(nameof(CurrentView));
        }
    }

    //private UserControl _currentView = WorkflowManagerer.GetView("MainUC");

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
        LanguageEventHandler.InvokeEvent();
    }

    private void SetENLanguage()
    {
        LanguageManager.SetLanguageResource("EN");
        LanguageEventHandler.InvokeEvent();
    }
    /// <summary>
    /// Opening buttons
    /// </summary>
    private void NewCharacter()
    {
        //WorkflowManager.CreateViewModels();
        //WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("CharacterUC"));
        //SetCurrentView(_serviceProvider.GetService<CharacterViewModel>().GetView());
        _player = new Player(_characterViewModel.GetCharacterModel(), _inventoryViewModel.GetInventoryModel(), _skillViewModel.GetSkillModel(), _loreViewModel.GetLoreModel(), _notesViewModel.GetNotesModel());
        SetCurrentView(_characterViewModel.GetView());
        Visibility = true;
        //LanguageChanged?.Invoke(this, EventArgs.Empty);
    }

    private async void LoadCharacter()
    {
        _player = await PlayerStorage.LoadPlayerAsync();
        _characterViewModel.SetCharacterModel(_player.CharacterModel);
        //_characterViewModel = cVM;
        //_inventoryViewModel = iVM;
        //_skillViewModel = sVM;
        //_loreViewModel = lVM;
        //_notesViewModel = nVM;
        Visibility = true;
        SetCurrentView(_characterViewModel.GetView());
        //throw new NotImplementedException();
    }
    /// <summary>
    /// Diary Player buttons
    /// </summary>
    private void CharacterScreen()
    {
        //WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("CharacterUC"));
        //SetCurrentView(_serviceProvider.GetService<CharacterViewModel>().GetView());
        SetCurrentView(_characterViewModel.GetView());
    }
    private void InventoryScreen()
    {
        //WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("InventoryUC"));
        //SetCurrentView(_serviceProvider.GetService<InventoryViewModel>().GetView());
        SetCurrentView(_inventoryViewModel.GetView());
    }
    private void SkillScreen()
    {
        //WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("SkillUC"));
        //SetCurrentView(_serviceProvider.GetService<SkillViewModel>().GetView());
        SetCurrentView(_skillViewModel.GetView());
    }
    private void LoreScreen()
    {
        //WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("LoreUC"));
        //SetCurrentView(_serviceProvider.GetService<LoreViewModel>().GetView());
        SetCurrentView(_loreViewModel.GetView());
    }
    private void NotesScreen()
    {
        //WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("NotesUC"));
        //SetCurrentView(_serviceProvider.GetService<NotesViewModel>().GetView());
        SetCurrentView(_notesViewModel.GetView());
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
