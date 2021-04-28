using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Aura.UI.Gallery.ReactivePages
{
    public partial class ReactiveAuraTabViewPage : UserControl
    {
        public ReactiveAuraTabViewPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}