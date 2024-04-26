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

    public MainViewModel()
    {
        mainView = new MainView() { DataContext = this };
    }

    public UserControl GetView()
    {
        return mainView;
    }
}
