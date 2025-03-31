using AngelSix.BatchProcess.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AngelSix.BatchProcess.ViewModels.Pages;

public partial class HomePageViewModel()
    : PageViewModel(ApplicationPageName.Home)
{
    [ObservableProperty] private string _pageSubTitle;
}
