using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;

namespace Aura.UI.Extensions
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

        public static void SetCanvasMargin(this Control control, double top = 0, double bottom = 0, double left = 0, double right = 0)
        {
            Canvas.SetTop(control, top);
            Canvas.SetBottom(control, bottom);
            Canvas.SetLeft(control, left);
            Canvas.SetRight(control, right);
        }

        public static void GetCanvasMargin(this Control control, out double top, out double bottom, out double left, out double right)
        {
            top = Canvas.GetLeft(control);
            bottom = Canvas.GetBottom(control);
            left = Canvas.GetLeft(control);
            right = Canvas.GetRight(control);
        }

        public static bool PointerEffectivelyOver(this Control control, PointerEventArgs e)
            => new Rect(control.Bounds.Size).Contains(e.GetPosition(control));
    }
}