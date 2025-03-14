using AngelSix.BatchProcess.ViewModels;
using Avalonia.Controls;

namespace AngelSix.BatchProcess
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Svg_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            if (e.ClickCount != 2)
            {
                return;
            }

            (DataContext as MainViewModel)?.SideMenuResizeCommand?.Execute(this);
        }
    }
}