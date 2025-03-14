using AngelSix.BatchProcess.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AngelSix.BatchProcess.ViewModels.Pages;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty] private ApplicationPageName _pageName;
}
