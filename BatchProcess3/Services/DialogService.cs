using System.Threading.Tasks;
using AngelSix.BatchProcess.Interfaces;
using AngelSix.BatchProcess.ViewModels.Dialogs;

namespace AngelSix.BatchProcess.Services;

public class DialogService
{
    public async Task ShowDialogAsync<THost, TDialogViewModel>(
        THost host,
        TDialogViewModel dialogViewModel)
        where TDialogViewModel : DialogViewModel
        where THost: IDialogProvider
    {
        // Set host dialog to provided one
        host.Dialog = dialogViewModel;
        dialogViewModel.Show();

        // Wait for dialog close
        await dialogViewModel.WaitAsync();
    }
}
