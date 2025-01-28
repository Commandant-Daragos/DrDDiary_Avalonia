using Avalonia;
using Avalonia.Diagnostics;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DrDDiary.Helpers;
using DrDDiary.Interfaces.PlayerInterfaces;
using DrDDiary.Models;
using DrDDiary.ViewModels;
using DrDDiary.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Numerics;
using System;
using DrDDiary.Models.PlayerModel;
using Avalonia.Controls;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using DrDDiary.Helpers.ValueConverter.BitMapSurrogate;

namespace DrDDiary;

public partial class App : Application
{
    public static Window? MainWindowInstance { get; private set; }
    private MainWindowViewModel? _mainWindowViewModel;


    public override void Initialize()
    {
        RegisterBitmapSurrogate();
        AvaloniaXamlLoader.Load(this);

        DevToolsExtensions.AttachDevTools(Application.Current); //For Avalonia diagnostics
    }

    private void RegisterBitmapSurrogate()
    {
        // Register the surrogate for Bitmap
        ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(Avalonia.Media.Imaging.Bitmap), false)
            .SetSurrogate(typeof(BitmapSurrogate));
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();

        _mainWindowViewModel = serviceProvider.GetService<MainWindowViewModel>();

        //WorkflowManager.CreateMainViewModel();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            //MainWindowViewModel viewModel = new MainWindowViewModel();
            //WorkflowManager.mainWindowViewModel = viewModel;
            desktop.MainWindow = _mainWindowViewModel.GetMainWindow();//viewModel.GetMainWindow();
            MainWindowInstance = desktop.MainWindow;//viewModel.GetMainWindow();
            //desktop.MainWindow = new MainWindow
            //{
            //    DataContext = new MainWindowViewModel()
            //};
        }
        //else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        //{

        //    singleViewPlatform.MainView = new MainView
        //    {
        //        DataContext = new MainWindowViewModel(serviceProvider)
        //    };
        //}

        base.OnFrameworkInitializationCompleted();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Register Views
        services.AddSingleton<CharacterView>()
                .AddSingleton<InventoryView>()
                .AddSingleton<SkillView>()
                .AddSingleton<LoreView>()
                .AddSingleton<NotesView>();

        // Register view models
        //services.AddSingleton<>();
        services.AddSingleton<MainWindowViewModel>()
                .AddSingleton<MainViewModel>()
                .AddSingleton<CharacterViewModel>()
                .AddSingleton<InventoryViewModel>()
                .AddSingleton<SkillViewModel>()
                .AddSingleton<LoreViewModel>()
                .AddSingleton<NotesViewModel>();

        // Register Models
        services.AddSingleton<CharacterModel>()
                .AddSingleton<InventoryModel>()
                .AddSingleton<SkillModel>()
                .AddSingleton<LoreModel>()
                .AddSingleton<NotesModel>()
                .AddSingleton<Player>();

        Create().GetAwaiter().GetResult();
    }

    public async Task Create()
    {

    }
}
