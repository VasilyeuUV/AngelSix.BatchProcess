using AngelSix.BatchProcess.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AngelSix.BatchProcess.ViewModels.Pages;

/// <summary>
/// CTOR.
/// </summary>
public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty] private ApplicationPageName _pageName;

    protected PageViewModel(ApplicationPageName pageName)
    {
        PageName = pageName;

        // Detect design time
        if (Avalonia.Controls.Design.IsDesignMode)
        {
            OnDesignTimeConstructor();
        }
    }

    protected virtual void OnDesignTimeConstructor()
    {
    }
}
