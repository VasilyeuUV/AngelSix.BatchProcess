using System;
using System.Collections.ObjectModel;
using System.Linq;
using AngelSix.BatchProcess.Data;
using AngelSix.BatchProcess.ViewModels.UserControls;
using AngelSix.BatchProcess.ViewModels.ValueObjects;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AngelSix.BatchProcess.ViewModels.Pages;

public partial class ActionsPageViewModel()
    : PageViewModel(ApplicationPageName.Actions)
{
    // TODO: Remove once we have database service
    private ActionsPrinterProfileViewModel _defaultPrinterProfile = new()
    {
        Id = "0",
        Name = "(Default)",
        Description = "Use all default settings",
        Copies = 1
        // TODO^ Populate PrinterSettings
    };

    [ObservableProperty] private ObservableCollection<ActionsPrintViewModel> _printList = [];
    [ObservableProperty] private ObservableCollection<ActionsPrinterProfileViewModel> _printerProfiles = [];
    [ObservableProperty] private ActionsPrintViewModel? _selectedPrintListItem;


    [RelayCommand]
    public void RefreshActionsPage(ActionsPageName actionsPageName)
    {
        switch (actionsPageName)
        {
            case ActionsPageName.Print:
                FetchPrintActionsData();
                break;
        }
    }


    [RelayCommand]
    public void FetchPrintActionsData()
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
                    DrawingExclusionList = $"Some item 1{Environment.NewLine}Some item 2{Environment.NewLine}Some item 3",
                    PrinterProfile = _defaultPrinterProfile
                },
                new ActionsPrintViewModel
                {
                    Id = "2",
                    JobName = "Print All Drawings Scale To Fit",
                    Description = "Prints drawing scaled to fit the paper",
                    PrintDrawings = true,
                    PrinterProfile = _defaultPrinterProfile
                },
                new ActionsPrintViewModel
                {
                    Id = "3",
                    JobName = "Print 3D Models A3",
                    Description = "Prints models as 3D visuals",
                    PrintModels = true,
                    PrinterProfile = _defaultPrinterProfile
                },
            ];

        PrinterProfiles =
            [
                _defaultPrinterProfile,
                new ActionsPrinterProfileViewModel
                {
                    Name = "Print Landscape",
                    Description = "Print all files in landscape mode, 3 copies",
                    Copies = 3
                    // TODO^ Populate PrinterSettings
                },
                new ActionsPrinterProfileViewModel
                {
                    Name = "Print Portrait",
                    Description = "Print all files in portrait mode",
                    Copies = 1
                    // TODO^ Populate PrinterSettings
                },
                new ActionsPrinterProfileViewModel
                {
                    Name = "B&W A3",
                    Description = "Make all A3 prints black and white",
                    Copies = 5
                    // TODO^ Populate PrinterSettings
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
        // TODO: Fetch new item defaults from a service provider

        // Create a new item
        ActionsPrintViewModel newItem = new()
        {
            JobName = "New Print Item",
            IsSelected = true,
            IsNewItem = true,
            PrinterProfile = _defaultPrinterProfile
        };

        // Add to the PrintList
        PrintList.Add(newItem);
    }


    protected override void OnDesignTimeConstructor()
        => FetchPrintActionsData();
}