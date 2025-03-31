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
    private string _printerProfileId = "";

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

    public void RestoreSavedState()
    {
        var savedState = JsonSerializer.Deserialize<ActionsPrintViewModel>(_savedState);
        foreach (var propertyInfo in GetType().GetProperties())
        {
            // Only set setters, not get only properties
            if (!propertyInfo.CanWrite)
            {
                continue;
            }

            // Ignore any properties that have a JsonIgnore ayttribute
            if (propertyInfo.GetCustomAttributes(typeof(JsonIgnoreAttribute), inherit: false).GetLength(0) > 0)
            {
                continue;
            }

            // Pull the saved value
            var originalValue = propertyInfo.GetValue(savedState);

            // Restore it to this class
            propertyInfo.SetValue(this, originalValue);
        }
    }
}
