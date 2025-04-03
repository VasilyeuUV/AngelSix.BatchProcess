using AngelSix.BatchProcess.ViewModels.Dialogs;

namespace AngelSix.BatchProcess.Interfaces;

public interface IDialogProvider
{
    DialogViewModel Dialog { get; set; }
}
