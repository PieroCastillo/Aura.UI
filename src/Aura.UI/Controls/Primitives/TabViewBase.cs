using Avalonia;
using Avalonia.Controls;

namespace Aura.UI.Controls.Primitives
{
    public class TabViewBase : TabControl
    {
        protected virtual void OnSelectionChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
        }
    }
}