using AngelSix.BatchProcess.ViewModels.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AngelSix.BatchProcess.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private const string _buttonActiveClass = "active";

    private readonly HomePageViewModel _homePage = new();
    private readonly ProcessPageViewModel _processPage = new();

    [ObservableProperty] private string _title = "AngelSix.BatchProcess";
    [ObservableProperty] private bool _isSideMenuExpanded = false;                  // - show/hide side menu
    
    //public SvgImage Logo => new()
    //{
    //    Source = SvgSource.Load($"avares://{nameof(AngelSix.BatchProcess)}/Assets/Images/{(IsSideMenuExpanded ? "logo" : "logo")}.svg")
    //};
    //public string Logo => $"/Assets/Images/{(IsSideMenuExpanded ? "logo" : "logo")}.svg";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsActiveHomePage))]
    [NotifyPropertyChangedFor(nameof(IsActivProcessPage))]
    private ViewModelBase _currentPage;


    /// <summary>
    /// CTOR
    /// </summary>
    public MainViewModel()
    {
        CurrentPage = _homePage;
    }

    public bool IsActiveHomePage => CurrentPage == _homePage;
    public bool IsActivProcessPage => CurrentPage == _processPage;


    [RelayCommand] private void SideMenuResize() => IsSideMenuExpanded = !IsSideMenuExpanded;
    [RelayCommand] private void GoToHome() => CurrentPage = _homePage;
    [RelayCommand] private void GoToProcess() => CurrentPage = _processPage;
}
