using System;
using Aura.UI.UIExtensions;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;

namespace Aura.UI.Controls.Thumbs
{
    public class MoveThumb : Thumb, IControl
    {
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            var b = this.GetControl<Control>(e, "PartControl");
            b.SetCursorOnPointerPressed(StandardCursorType.Arrow);
        }

        protected override void OnDragDelta(VectorEventArgs e)
        {
            base.OnDragDelta(e);

            Control item = this.DataContext as Control;
            
            if(item != null)
            {
                double delta_v, delta_h;
                delta_v = Math.Min(e.Vector.Y, item.Bounds.Height - item.MinHeight);
                Canvas.SetTop(item, Canvas.GetTop(item) + delta_v);
                delta_h = Math.Min(e.Vector.X, item.Bounds.Width + item.MinWidth);
                Canvas.SetLeft(item, Canvas.GetLeft(item) + delta_h);
            }
        }
    }
}