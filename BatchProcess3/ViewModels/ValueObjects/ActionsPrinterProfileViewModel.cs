using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AngelSix.BatchProcess.ViewModels.ValueObjects;

public partial class ActionsPrinterProfileViewModel : ViewModelBase
{
    [ObservableProperty] private string _id;
    [ObservableProperty] private string _name;
    [ObservableProperty] private string _description;
    [ObservableProperty] private int _copies;
    [ObservableProperty] private ObservableCollection<ActionsPrinterSettingsViewModel> _printerSettings;
}
