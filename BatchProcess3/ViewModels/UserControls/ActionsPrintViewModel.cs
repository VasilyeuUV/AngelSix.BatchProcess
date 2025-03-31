using System.Text.Json;
using System.Text.Json.Serialization;
using AngelSix.BatchProcess.ViewModels.ValueObjects;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AngelSix.BatchProcess.ViewModels.UserControls;

public partial class ActionsPrintViewModel : ViewModelBase
{
    [JsonIgnore]
    private string _savedState = string.Empty;

    [ObservableProperty] private bool _isNewItem;
    
    [ObservableProperty]
    [property: JsonIgnore]
    private bool _isSelected;

    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(HasChanged))]
    private string _id = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasChanged))]
    private string _jobName = string.Empty;

    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(HasChanged))]
    private string _description = string.Empty;

    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(HasChanged))]
    private string _printDrawingRange = string.Empty;

    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(HasChanged))]
    private string _drawingExclusionList = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasChanged))]
    private bool _printModels;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasChanged))]
    private bool _printDrawings;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasChanged))]
    private ActionsPrinterProfileViewModel _printerProfile = new();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DrawingExclusionListTitle))]
    [NotifyPropertyChangedFor(nameof(HasChanged))]
    private bool _drawingExclusionIsWhiteList;

    public string DrawingExclusionListTitle => DrawingExclusionIsWhiteList
        ? "White List"
        : "Black List";

    [JsonIgnore]
    public bool HasChanged => IsNewItem
        || (_savedState != ""
            && _savedState != JsonSerializer.Serialize(this));

    public void SetSavedState()
    {
        _savedState = JsonSerializer.Serialize(this);
        OnPropertyChanged(nameof(HasChanged));
    }
}
