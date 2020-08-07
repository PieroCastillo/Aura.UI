using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Aura.UI.Controls
{
    public class GradientEditor : UserControl
    {
        public GradientEditor()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
