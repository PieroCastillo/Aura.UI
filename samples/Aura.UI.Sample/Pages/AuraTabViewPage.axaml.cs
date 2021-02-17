using Aura.UI.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Aura.UI.ControlsGallery.Pages
{
    public partial class AuraTabViewPage : UserControl
    {
        public AuraTabViewPage()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void AddTab(object sender, RoutedEventArgs e)
        {
            var atw = sender as AuraTabView;

            atw.AddTab(new AuraTabItem { Header = "Header", Content = new TextBlock { Text = "Content", Margin = new Thickness(10) } });
        }
    }
}
