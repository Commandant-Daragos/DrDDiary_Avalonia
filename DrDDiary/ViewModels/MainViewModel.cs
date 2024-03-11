using ReactiveUI;
using System;
using System.Reactive;

namespace DrDDiary.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> NewCharButtonClicked { get; set; }
    public ReactiveCommand<Unit, Unit> LoadCharButtonClicked { get; set; }

    public MainViewModel()
    {
        NewCharButtonClicked = ReactiveCommand.Create(NewCharacter);
        LoadCharButtonClicked = ReactiveCommand.Create(LoadCharacter);
    }

    private void NewCharacter()
    {
        throw new NotImplementedException();
    }

    private void LoadCharacter()
    {
        throw new NotImplementedException();
    }
}
