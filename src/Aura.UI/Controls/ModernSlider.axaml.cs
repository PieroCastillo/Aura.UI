using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace Aura.UI.Controls
{
    public class ModernSlider : FilledSlider
    {
        public ModernSlider()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public Color TintColor
        {
            get { return GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }
        public static readonly StyledProperty<Color> TintColorProperty =
            AvaloniaProperty.Register<ModernSlider, Color>(nameof(TintColor), Colors.White);
    }
}
