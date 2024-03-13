using Avalonia.Controls;
using DrDDiary.Helpers;
using DrDDiary.Interfaces;
using DrDDiary.Views;
using ReactiveUI;
using System;
using System.Reactive;

namespace DrDDiary.ViewModels;

public class MainViewModel : ViewModelBase, IUserControlViewModel
{
    private MainView mainView;

    public ReactiveCommand<Unit, Unit> NewCharButtonClicked { get; set; }
    public ReactiveCommand<Unit, Unit> LoadCharButtonClicked { get; set; }

    public MainViewModel()
    {
        NewCharButtonClicked = ReactiveCommand.Create(NewCharacter);
        LoadCharButtonClicked = ReactiveCommand.Create(LoadCharacter);
        mainView = new MainView() { DataContext = this };
    }

    private void NewCharacter()
    {
        WorkflowManager.mainWindowViewModel.SetCurrentView(WorkflowManager.GetView("CharacterUC"));
    }

    private void LoadCharacter()
    {
        throw new NotImplementedException();
    }

    public UserControl GetView()
    {
        return mainView;
    }
}
