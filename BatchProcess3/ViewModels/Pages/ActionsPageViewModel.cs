using System.Collections.ObjectModel;
using AngelSix.BatchProcess.Data;
using AngelSix.BatchProcess.ViewModels.UserControls;
using CommunityToolkit.Mvvm.Input;

namespace AngelSix.BatchProcess.ViewModels.Pages;

public partial class ActionsPageViewModel()
    : PageViewModel(ApplicationPageName.Actions)
{
    private ObservableCollection<ActionsPrintViewModel> _printList;


    [RelayCommand]
    public void RefreshActionsPage(ActionsPageName actionsPageName)
    {
        switch (actionsPageName)
        {
            case ActionsPageName.Print:
                FetchPrintList();
                break;
        }
    }


    [RelayCommand]
    public void FetchPrintList()
    {
        //TODO: Fetch from a database/service provider
        _printList =
            [
                new ActionsPrintViewModel{Id = "1", JobName = "Print Only Drawings"},
                new ActionsPrintViewModel{Id = "2", JobName = "Print All Drawings Scale To Fit"},
                new ActionsPrintViewModel{Id = "3", JobName = "Print 3D Models A3"},
            ];
    }
}