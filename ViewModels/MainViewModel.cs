using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AngelSix.BatchProcess.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _title = "AngelSix.BatchProcess";

    [ObservableProperty]
    //[NotifyPropertyChangedFor(nameof(SideMenuWidth))]
    private bool _isSideMenuExpanded = false;       // - show/hide side menu

    //public SvgImage Logo => new()
    //{
    //    Source = SvgSource.Load($"avares://{nameof(AngelSix.BatchProcess)}/Assets/Images/{(IsSideMenuExpanded ? "logo" : "logo")}.svg")
    //};
    //public string Logo => $"/Assets/Images/{(IsSideMenuExpanded ? "logo" : "logo")}.svg";

    //public int SideMenuWidth => IsSideMenuExpanded ? 160 : 65;


    [RelayCommand]
    private void SideMenuResize()
    {
        IsSideMenuExpanded = !IsSideMenuExpanded;
    }
}
