using System;
using System.Collections.ObjectModel;
using System.Linq;
using AngelSix.BatchProcess.Data;
using AngelSix.BatchProcess.ViewModels.UserControls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AngelSix.BatchProcess.ViewModels.Pages;

public partial class ActionsPageViewModel()
    : PageViewModel(ApplicationPageName.Actions)
{
    [ObservableProperty] private ObservableCollection<ActionsPrintViewModel> _printList = [];
    [ObservableProperty] private ActionsPrintViewModel? _selectedPrintListItem;


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
        PrintList =
            [
                new ActionsPrintViewModel
                {
                    Id = "1",
                    JobName = "Print Only Drawings",
                    Description = "Print only drawing files",
                    PrintDrawingRange = "0, 5, 7-8",
                    PrintDrawings = true,
                    DrawingExclusionList = $"Some item 1{Environment.NewLine}Some item 2{Environment.NewLine}Some item 3"
                },
                new ActionsPrintViewModel
                {
                    Id = "2",
                    JobName = "Print All Drawings Scale To Fit",
                    Description = "Prints drawing scaled to fit the paper",
                    PrintDrawings = true
                },
                new ActionsPrintViewModel
                {
                    Id = "3",
                    JobName = "Print 3D Models A3",
                    Description = "Prints models as 3D visuals",
                    PrintModels = true
                },
            ];
    }

    [RelayCommand]
    public void DeletePrintItem(string id)
    {
        // TODO: Pass this logic to a service that handles the database/storage/fetching
        // For now just do it direct in here

        if (PrintList.Count(x => x.Id == id) != 1)
        {
            // TODO: Throw/Warn?
        }

        // Remove item
        PrintList.Remove(PrintList.First(x => x.Id == id));
    }


    [RelayCommand]
    public void AddNewPrintItem()
    {
        // Create a new item
        ActionsPrintViewModel newItem = new()
        {
            JobName = "New Print Item",
            IsSelected = true,
            IsNewItem = true,
        };

        // Add to the PrintList
        PrintList.Add(newItem);
    }


    protected override void OnDesignTimeConstructor()
        => FetchPrintList();
}