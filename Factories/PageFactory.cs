using System;
using AngelSix.BatchProcess.Data;
using AngelSix.BatchProcess.ViewModels.Pages;

namespace AngelSix.BatchProcess.Factories;

public class PageFactory(Func<ApplicationPageName, PageViewModel> factory)
{
    public PageViewModel GetPageViewModel(ApplicationPageName pageName)
        => factory.Invoke(pageName);
}
