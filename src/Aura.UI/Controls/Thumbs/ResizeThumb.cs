using System;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Layout;

namespace Aura.UI.Controls.Thumbs
{
    public class ResizeThumb : Thumb
    {
        protected override void OnDragDelta(VectorEventArgs e)
        {
            base.OnDragDelta(e);

            Control item = this.DataContext as Control;
            if (item != null)
            {
                double delta_v, delta_h;
                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Bottom:
                        delta_v = Math.Min(-e.Vector.Y, item.Bounds.Height + item.MinHeight);
                        item.Height -= delta_v;
                        break;
                    case VerticalAlignment.Top:
                        delta_v = Math.Min(e.Vector.Y, item.Bounds.Height + item.MinHeight);
                        Canvas.SetTop(item, Canvas.GetTop(item) + delta_v);
                        item.Height -= delta_v;
                        break;
                }

                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        delta_h = Math.Min(e.Vector.X, item.Bounds.Width - item.MinWidth);
                        Canvas.SetLeft(item, Canvas.GetLeft(item) + delta_h);
                        item.Width -= delta_h;
                        break;
                    case HorizontalAlignment.Right:
                        delta_h = Math.Min(e.Vector.X, item.Bounds.Width + item.MinWidth);
                        Canvas.SetRight(item, Canvas.GetRight(item) + delta_h);
                        item.Width += delta_h;
                        break;
                }
            }

            e.Handled = true;
        }
    }
}