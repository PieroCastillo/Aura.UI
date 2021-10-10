using Avalonia.Controls;
using Avalonia.Media;

namespace Aura.UI.Controls
{
    /// <summary>
    /// The Content can be an <see cref="IImage"/> only.
    /// </summary>
    public class FloatingButton : Button
    {
        static FloatingButton()
        {
            ClipToBoundsProperty.OverrideDefaultValue<FloatingButton>(false);
        }
    }
}