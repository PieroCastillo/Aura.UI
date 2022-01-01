using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Input;

namespace Aura.UI.Controls.Primitives
{
    [PseudoClasses(":pressed")]
    public class PressedGrid : Grid
    {
        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);

            PseudoClasses.Add(":pressed");
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);
            PseudoClasses.Remove(":pressed");
        }
    }
}