using Aura.UI.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Aura.UI.Gallery.Pages
{
    public partial class AuraTabViewPage : UserControl
    {
        public AuraTabViewPage()
        {
            InitializeComponent();
        }

        public void AddTab(object sender, RoutedEventArgs e)
        {
            var atw = sender as AuraTabView;

            atw.AddTab(new AuraTabItem { Header = "Header", Content = new TextBlock { Text = "Content", Margin = new Thickness(10) } });
        }
    }
}
