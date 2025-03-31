using System;
using AngelSix.BatchProcess.Factories;
using AngelSix.BatchProcess.ViewModels;
using AngelSix.BatchProcess.ViewModels.Pages;
using AngelSix.BatchProcess.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Metadata;
using Microsoft.Extensions.DependencyInjection;

[assembly: XmlnsDefinition("https://github.com/avaloniaui", "AngelSix.BatchProcess.Controls")]

namespace AngelSix.BatchProcess
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            //DataTemplates.Add(new ViewLocator());     // - подключаем в app.axaml
        }

        public override void OnFrameworkInitializationCompleted()
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);

            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<MainViewModel>();
            serviceCollection.AddSingleton<ActionsPageViewModel>();
            serviceCollection.AddSingleton<HistoryPageViewModel>();
            serviceCollection.AddSingleton<HomePageViewModel>();
            serviceCollection.AddSingleton<MacrosPageViewModel>();
            serviceCollection.AddSingleton<ProcessPageViewModel>();
            serviceCollection.AddSingleton<ReporterPageViewModel>();
            serviceCollection.AddSingleton<SettingsPageViewModel>();

            serviceCollection.AddSingleton<Func<Type, PageViewModel>>(x => type => type switch
            {
                _ when type == typeof(ActionsPageViewModel) => x.GetRequiredService<ActionsPageViewModel>(),
                _ when type == typeof(HistoryPageViewModel) => x.GetRequiredService<HistoryPageViewModel>(),
                _ when type == typeof(HomePageViewModel) => x.GetRequiredService<HomePageViewModel>(),
                _ when type == typeof(MacrosPageViewModel) => x.GetRequiredService<MacrosPageViewModel>(),
                _ when type == typeof(ProcessPageViewModel) => x.GetRequiredService<ProcessPageViewModel>(),
                _ when type == typeof(ReporterPageViewModel) => x.GetRequiredService<ReporterPageViewModel>(),
                _ when type == typeof(SettingsPageViewModel) => x.GetRequiredService<SettingsPageViewModel>(),
                _ => throw new NotImplementedException(),
            });

            serviceCollection.AddSingleton<PageFactory>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();


            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = serviceProvider.GetRequiredService<MainViewModel>()
                    //DataContext = new ViewModels._Test.MyViewModel()
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = serviceProvider.GetRequiredService<MainViewModel>()
                };
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}