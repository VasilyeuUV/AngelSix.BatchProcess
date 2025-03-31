using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AngelSix.BatchProcess.ViewModels.Dialogs;

public partial class ConfirmDialogViewModel : DialogViewModel
{
    [ObservableProperty] private string _title = "Confirm";
    [ObservableProperty] private string _message = "Are you sure?";
    [ObservableProperty] private string _confirmText = "Yes";
    [ObservableProperty] private string _cancelText = "No";
    [ObservableProperty] private string _iconText = "\xE4E0";
    [ObservableProperty] private bool _confirmed;


    [RelayCommand]
    public void Confirm()
    {
        Confirmed = true;
        Close();
    }


    [RelayCommand]
    public void Cancel()
    {
        Confirmed = false;
        Close();
    }
}
