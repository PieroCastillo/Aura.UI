using Avalonia.Controls;

namespace Aura.UI.Controls.Ribbon
{
    /// <summary>
    /// This Panel has a pre-defined properties fot the <see cref="RibbonItem"/>
    /// </summary>
    public class RibbonPanel : StackPanel
    {
        public RibbonPanel()
        {
            Spacing = 10;
            Orientation = Avalonia.Layout.Orientation.Horizontal;
        }
    }
}