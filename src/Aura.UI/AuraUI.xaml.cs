using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Aura.UI
{
    public class AuraUITheme : Styles
    {
        public AuraUITheme()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}