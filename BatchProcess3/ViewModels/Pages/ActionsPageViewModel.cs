using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AngelSix.BatchProcess.Data;
using AngelSix.BatchProcess.Services;
using AngelSix.BatchProcess.ViewModels.Dialogs;
using AngelSix.BatchProcess.ViewModels.UserControls;
using AngelSix.BatchProcess.ViewModels.ValueObjects;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AngelSix.BatchProcess.ViewModels.Pages;

public partial class ActionsPageViewModel(
    MainViewModel mainViewModel,
    DialogService dialogService)
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

    [ObservableProperty]
    private ObservableCollection<ActionsPrinterProfileViewModel> _printerProfiles = [];

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(SelectedPrintListItem))]
    private string _selectedPrintListItemId = "";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PrintListHasItems))]
    private ObservableCollection<ActionsPrintViewModel> _printList = [];

    public bool PrintListHasItems => PrintList.Any();


    public ActionsPrintViewModel? SelectedPrintListItem => PrintList.FirstOrDefault(f => f.Id == SelectedPrintListItemId);


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
                    PrinterProfileId = "1"
                },
                new ActionsPrintViewModel
                {
                    Id = "2",
                    JobName = "Print All Drawings Scale To Fit",
                    Description = "Prints drawing scaled to fit the paper",
                    PrintDrawings = true,
                    PrinterProfileId = "2"
                },
                new ActionsPrintViewModel
                {
                    Id = "3",
                    JobName = "Print 3D Models A3",
                    Description = "Prints models as 3D visuals",
                    PrintModels = true,
                    PrinterProfileId = "3"
                },
            ];

        // Update PrintListHasItems, when collection changes
        PrintList.CollectionChanged += (_, _) => OnPropertyChanged(nameof(PrintListHasItems));

        if (PrintList.Count > 0)
        {
            // Select first item
            SelectedPrintListItemId = PrintList.First().Id;

            // Store last fetched database save states
            foreach (var printItem in PrintList)
            {
                printItem.SetSavedState();
            }
        }
    }

    [RelayCommand]
    public async Task DeletePrintItemAsync(string id)
    {
        // TODO: Pass this logic to a service that handles the database/storage/fetching
        // For now just do it direct in here

        if (PrintList.Count(x => x.Id == id) != 1)
        {
            // TODO: Throw/Warn?
        }

        await DeletePrintItemFromUIAsync(id);
    }


    [RelayCommand]
    public void AddNewPrintItem()
    {
        // TODO: Fetch new item defaults from a service provider

        // Create a new item
        ActionsPrintViewModel newItem = new()
        {
            Id = Guid.NewGuid().ToString("N"),
            JobName = "New Print Item",
            IsNewItem = true,
            PrinterProfileId = "0"
        };

        // Add to the PrintList
        PrintList.Add(newItem);

        // SelectItem
        SelectedPrintListItemId = newItem.Id;
    }


    [RelayCommand]
    public async Task CancelPrintItemAsync()
    {
        // Ignore is nothing is selected
        if (SelectedPrintListItem is null)
        {
            return;
        }

        // If the selected item is new, delete it otherwise, restore from save state
        if (SelectedPrintListItem.IsNewItem)
        {
            await DeletePrintItemFromUIAsync(SelectedPrintListItem.Id, warn: false);
        }
        else
        {
            SelectedPrintListItem.RestoreSavedState();
        }
    }

    private async Task DeletePrintItemFromUIAsync(string id, bool warn = true)
    {
        var index = PrintList.IndexOf(PrintList.First(x => x.Id == id));
        if (index == -1)
        {
            return;
        }

        if (warn)
        {

            var confirmViewModel = new ConfirmDialogViewModel
            {
                Title = $"Delete {PrintList[index].JobName}?",
                Message = "Are you sure you want to delete this print?"
            };

            await dialogService.ShowDialogAsync(mainViewModel, confirmViewModel);

            // Ignore if we clecked cancel
            if (!confirmViewModel.Confirmed)
            {
                return;
            }
        }

        // Remove item
        PrintList.RemoveAt(index);

        if (index > 0)
        {
            index--;
        }

        if (PrintList.Count > 0)
        {
            SelectedPrintListItemId = PrintList[index].Id;
        }
    }

    protected override void OnDesignTimeConstructor()
        => FetchPrintActionsData();
}