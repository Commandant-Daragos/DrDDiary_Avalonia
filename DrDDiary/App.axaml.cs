using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DrDDiary.Helpers;
using DrDDiary.ViewModels;
using DrDDiary.Views;

namespace DrDDiary;

public partial class App : Application
{
    public static MainWindow MainWindowInstance { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        WorkflowManager.CreateMainViewModel();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            WorkflowManager.mainWindowViewModel = viewModel;
            desktop.MainWindow = viewModel.GetMainWindow();
            MainWindowInstance = viewModel.GetMainWindow();
            //desktop.MainWindow = new MainWindow
            //{
            //    DataContext = new MainWindowViewModel()
            //};
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {

            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainWindowViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
