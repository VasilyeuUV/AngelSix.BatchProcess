﻿using AngelSix.BatchProcess.Data;
using AngelSix.BatchProcess.Factories;
using AngelSix.BatchProcess.Interfaces;
using AngelSix.BatchProcess.ViewModels.Dialogs;
using AngelSix.BatchProcess.ViewModels.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AngelSix.BatchProcess.ViewModels;

public partial class MainViewModel : ViewModelBase, IDialogProvider
{
    private const string _buttonActiveClass = "active";

    private readonly PageFactory _pageFactory;

    [ObservableProperty] private string _title = "AngelSix.BatchProcess";
    [ObservableProperty] private bool _isSideMenuExpanded = true;                                   // - show/hide side menu

    [ObservableProperty] private DialogViewModel _dialog;// = new ConfirmDialogViewModel()      // - user dialogs
    //{ 
    //    IsDialogOpen = true 
    //};
    
    //public SvgImage Logo => new()
    //{
    //    Source = SvgSource.Load($"avares://{nameof(AngelSix.BatchProcess)}/Assets/Images/{(IsSideMenuExpanded ? "logo" : "logo")}.svg")
    //};
    //public string Logo => $"/Assets/Images/{(IsSideMenuExpanded ? "logo" : "logo")}.svg";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsActiveHomePage))]
    [NotifyPropertyChangedFor(nameof(IsActiveProcessPage))]
    [NotifyPropertyChangedFor(nameof(IsActiveActionsPage))]
    [NotifyPropertyChangedFor(nameof(IsActiveMacrosPage))]
    [NotifyPropertyChangedFor(nameof(IsActiveReporterPage))]
    [NotifyPropertyChangedFor(nameof(IsActiveHistoryPage))]
    [NotifyPropertyChangedFor(nameof(IsActiveSettingsPage))]
    private PageViewModel _currentPage;


    /// <summary>
    /// Design-time only constructor
    /// </summary>
    public MainViewModel()
    {
        CurrentPage = new SettingsPageViewModel();
    }

    /// <summary>
    /// CTOR
    /// </summary>
    public MainViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;
        GoToHome();
    }


    public bool IsActiveHomePage => CurrentPage.PageName == ApplicationPageName.Home;
    public bool IsActiveProcessPage => CurrentPage.PageName == ApplicationPageName.Process;
    public bool IsActiveActionsPage => CurrentPage.PageName == ApplicationPageName.Actions;
    public bool IsActiveMacrosPage => CurrentPage.PageName == ApplicationPageName.Macros;
    public bool IsActiveReporterPage => CurrentPage.PageName == ApplicationPageName.Reporter;
    public bool IsActiveHistoryPage => CurrentPage.PageName == ApplicationPageName.History;
    public bool IsActiveSettingsPage => CurrentPage.PageName == ApplicationPageName.Settings;


    [RelayCommand] private void SideMenuResize() => IsSideMenuExpanded = !IsSideMenuExpanded;
    [RelayCommand] private void GoToHome()
        => CurrentPage = _pageFactory.GetPageViewModel<HomePageViewModel>(afterCreation => afterCreation.PageSubTitle = "Hello, world!");
    [RelayCommand] private void GoToProcess() => CurrentPage = _pageFactory.GetPageViewModel<ProcessPageViewModel>();
    [RelayCommand] private void GoToActions() => CurrentPage = _pageFactory.GetPageViewModel<ActionsPageViewModel>();
    [RelayCommand] private void GoToMacros() => CurrentPage = _pageFactory.GetPageViewModel<MacrosPageViewModel>();
    [RelayCommand] private void GoToReporter() => CurrentPage = _pageFactory.GetPageViewModel<ReporterPageViewModel>();
    [RelayCommand] private void GoToHistory() => CurrentPage = _pageFactory.GetPageViewModel<HistoryPageViewModel>();
    [RelayCommand] private void GoToSettings() => CurrentPage = _pageFactory.GetPageViewModel<SettingsPageViewModel>();
}
