using Aura.UI.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace UI.Tests.Views
{
    public class TabbedWindowTest : TabbedWindow
    {
        public TabbedWindowTest()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            this.AddActionToAddButton(_NewAddTab);
        }
        public void _NewAddTab()
        {
            var t = new AuraTabItem
            {
                Header = "New Tab"
            };
            this.AddTab(t);
        }

    }
}
