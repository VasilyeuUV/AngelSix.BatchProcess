using System;
using AngelSix.BatchProcess.Data;
using AngelSix.BatchProcess.ViewModels.Pages;

namespace AngelSix.BatchProcess.Factories;

public class PageFactory(Func<Type, PageViewModel> factory)
{
    public PageViewModel GetPageViewModel<T>(
        Action<T>? afterCreation = null)
        where T : PageViewModel
    {
        var viewModel = factory(typeof(T));
        afterCreation?.Invoke((T)viewModel);
        return viewModel;
    }
}
