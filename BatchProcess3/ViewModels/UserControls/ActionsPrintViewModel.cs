using CommunityToolkit.Mvvm.ComponentModel;

namespace AngelSix.BatchProcess.ViewModels.UserControls;

public partial class ActionsPrintViewModel : ViewModelBase
{
    [ObservableProperty] private string _id;
    [ObservableProperty] private string _jobName;
    [ObservableProperty] private bool _isSelected;
}
