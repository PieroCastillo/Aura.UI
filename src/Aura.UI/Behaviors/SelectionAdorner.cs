using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace Aura.UI.Behaviors
{
    public class SelectionAdorner : Control
    {
        public override void Render(DrawingContext context)
        {
            var adornedElement = GetValue(AdornerLayer.AdornedElementProperty);
            if (adornedElement is null)
            {
                return;
            }
 
            var bounds = adornedElement.Bounds;
            var brush = new SolidColorBrush(Colors.White) { Opacity = 0.5 };
            var pen = new Pen(new SolidColorBrush(Colors.Black), 1.5);
            var r = 5.0;
            var topLeft = new EllipseGeometry(new Rect(-r, -r, r + r, r + r));
            var topRight = new EllipseGeometry(new Rect(-r, bounds.Height - r, r + r, r + r));
            var bottomLeft = new EllipseGeometry(new Rect(bounds.Width - r, -r, r + r, r + r));
            var bottomRight = new EllipseGeometry(new Rect(bounds.Width - r, bounds.Height - r, r + r, r + r));

            context.DrawGeometry(brush, pen, topLeft);
            context.DrawGeometry(brush, pen, topRight);
            context.DrawGeometry(brush, pen, bottomLeft);
            context.DrawGeometry(brush, pen, bottomRight);
        }
    }
}