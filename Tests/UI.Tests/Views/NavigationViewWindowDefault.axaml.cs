using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UI.Tests.Views
{
    public class NavigationViewWindowDefault : Window
    {
        public NavigationViewWindowDefault()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
