using System;
using AngelSix.BatchProcess.Data;
using AngelSix.BatchProcess.ViewModels.Pages;
using AngelSix.BatchProcess.Views.UserControls;
using Avalonia.Controls;

namespace AngelSix.BatchProcess.Views.Pages;

public partial class ActionsPageView : UserControl
{
    public ActionsPageView()
    {
        InitializeComponent();
    }


    protected override void OnInitialized()
    {
        // Fire off initial refresh
        OnTabChanged();
        base.OnInitialized();
    }

    private void ActionsTab_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (Equals(e.Source, ActionsTabControl))
        {
            OnTabChanged();
        }
    }

    private void OnTabChanged()
    {
        // —œŒ—Œ¡ ƒŒ¡–¿“‹—ﬂ ƒŒ ¬‹ﬁÃŒƒ≈À» »« ¬‹ﬁ.

        // Check we have an added item
        //if (e.AddedItems.Count < 1)
        //{
        //    return;
        //}

        // Get active tab control (Pages inside of each tab)
        Control? selectedPage = (ActionsTabControl?.SelectedItem as TabItem)?.Content as Control;
        if (selectedPage == null)
        {
            return;
        }

        // Convert to ActionsPageName
        ActionsPageName actionsPage = selectedPage switch
        {
            ActionsPrintView => ActionsPageName.Print,
            _ => ActionsPageName.Unknown
        };

        // Get ViewModel
        ActionsPageViewModel? viewModel = selectedPage.DataContext as ActionsPageViewModel;

        //Type check
        viewModel?.RefreshActionsPage(actionsPage);
    }
}