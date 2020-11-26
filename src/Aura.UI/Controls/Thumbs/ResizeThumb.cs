using System;
using System.Diagnostics;
using Aura.UI.UIExtensions;
using Avalonia;
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

                Rect r1 = item.Bounds;
                Rect cvr2 = item.GetParentTOfLogical<Canvas>().Bounds;
                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Bottom:
                        delta_v = Math.Min(-e.Vector.Y, item.Bounds.Height + item.MinHeight);
                        Rect _r1 = r1.WithY(Canvas.GetBottom(item) + delta_v);
                        if (cvr2.Contains(_r1))
                        {
                            item.Height -= delta_v;
                        }
                        break;
                    case VerticalAlignment.Top:
                        delta_v = Math.Min(e.Vector.Y, item.Bounds.Height + item.MinHeight);
                        Rect _r2 = r1.WithY(Canvas.GetTop(item) + delta_v);
                        if (cvr2.Contains(_r2)) 
                        {
                            Canvas.SetTop(item, Canvas.GetTop(item) + delta_v);
                            item.Height -= delta_v;
                        }
                        break;
                }

                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        delta_h = Math.Min(e.Vector.X, item.Bounds.Width - item.MinWidth);
                        Rect _r3 = r1.WithX(Canvas.GetLeft(item) + delta_h);
                        if (cvr2.Contains(_r3))
                        {
                            Canvas.SetLeft(item, Canvas.GetLeft(item) + delta_h);
                            item.Width -= delta_h;
                        }
                        break;
                    case HorizontalAlignment.Right:
                        delta_h = Math.Min(e.Vector.X, item.Bounds.Width + item.MinWidth);
                        Rect _r4 = r1.WithX(Canvas.GetRight(item) + delta_h);
                        if (cvr2.Contains(_r4)) ;
                        {
                            Canvas.SetRight(item, Canvas.GetRight(item) + delta_h);
                            item.Width += delta_h;
                        }
                        break;
                }
                #if DEBUG
                Debug.WriteLine($"canvas margin is Top : {Canvas.GetTop(item)}       Left : {Canvas.GetLeft(item)}");
                Debug.WriteLine($"                 Bottom : {Canvas.GetBottom(item)} Right : {Canvas.GetRight(item)}");
                #endif
            }
        }
    }
}