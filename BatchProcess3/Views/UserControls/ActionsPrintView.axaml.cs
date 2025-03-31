using AngelSix.BatchProcess.ViewModels.UserControls;
using Avalonia.Controls;

namespace AngelSix.BatchProcess.Views.UserControls;

public partial class ActionsPrintView : UserControl
{
    public ActionsPrintView()
    {
        InitializeComponent();
    }

    private void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        if (e.AddedItems?[0] is ActionsPrintViewModel viewModel)
        {
            // When a print view is selected
            viewModel.SetSavedState();

            // When it is a newly created item
            if (viewModel.IsNewItem)
            {
                JobNameTextBox.SelectAll();
                JobNameTextBox.Focus();
            }
        }
    }
}