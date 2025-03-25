using System.Collections.Generic;
using AngelSix.BatchProcess.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AngelSix.BatchProcess.ViewModels.Pages;

public partial class SettingsPageViewModel : PageViewModel
{
    [ObservableProperty] private List<string> _locationPaths;

    /// <summary>
    /// CTOR.
    /// </summary>
    public SettingsPageViewModel()
        : base(ApplicationPageName.Settings)
    {
        // TEMP: Remove
        LocationPaths =
            [
                @"C:\Users\Luke\Downloads\TestActions",
                @"C:\Users\Luke\Documents\BatchProcess",
                @"X:\Shared\BatchProcess\Templates",
            ];
    }
}
