using System;
using AngelSix.BatchProcess.Data;
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

            serviceCollection.AddSingleton<Func<ApplicationPageName, PageViewModel>>(x => name => name switch
            {
                ApplicationPageName.Actions => x.GetRequiredService<ActionsPageViewModel>(),
                ApplicationPageName.History => x.GetRequiredService<HistoryPageViewModel>(),
                ApplicationPageName.Home => x.GetRequiredService<HomePageViewModel>(),
                ApplicationPageName.Macros => x.GetRequiredService<MacrosPageViewModel>(),
                ApplicationPageName.Process => x.GetRequiredService<ProcessPageViewModel>(),
                ApplicationPageName.Reporter => x.GetRequiredService<ReporterPageViewModel>(),
                ApplicationPageName.Settings => x.GetRequiredService<SettingsPageViewModel>(),
                _ => throw new NotImplementedException(),
            });

            serviceCollection.AddSingleton<PageFactory>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();


            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = serviceProvider.GetRequiredService<MainViewModel>()
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = new MainViewModel()
                };
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}