using CommunityToolkit.Mvvm.ComponentModel;

namespace AngelSix.BatchProcess.ViewModels.UserControls;

public partial class ActionsPrintViewModel : ViewModelBase
{
    [ObservableProperty] private string _id;
    [ObservableProperty] private string _jobName;
    [ObservableProperty] private bool _isSelected;
    [ObservableProperty] private string _description;
    [ObservableProperty] private string _printDrawingRange;
    [ObservableProperty] private string _drawingExclusionList;
    [ObservableProperty] private bool _printModels;
    [ObservableProperty] private bool _printDrawings;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DrawingExclusionListTitle))]
    private bool _drawingExclusionIsWhiteList;

    public string DrawingExclusionListTitle => DrawingExclusionIsWhiteList
        ? "White List"
        : "Black List";
}
