using Avalonia.Controls;
using Avalonia.Input;

namespace Aura.UI.UIExtensions
{
    public static class ControlExtensions
    {
        public static void SetCursorOnPointerPressed(this Control control, StandardCursorType cursor)
        {
            if (control != null)
            {
                control.PointerPressed += (s, e) =>
                {
                    control.Cursor = new Cursor(cursor);
                };
            }
        }
    }
}