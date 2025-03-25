using AngelSix.BatchProcess.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AngelSix.BatchProcess.ViewModels.Pages;

/// <summary>
/// CTOR.
/// </summary>
public partial class PageViewModel(ApplicationPageName pageName)
    : ViewModelBase
{
    [ObservableProperty] private ApplicationPageName _pageName = pageName;
}
