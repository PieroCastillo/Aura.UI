using ABI.Windows.Foundation;
using Aura.UI.Controls.Editors;
using Aura.UI.UIExtensions;
using Avalonia.Controls;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Helpers
{
    public static class LayoutHelper
    { 
        public static void NewSizeBySide(this Control control, VectorEventArgs e, Side side)
        {
            var v = e.Vector;
            switch (side)
            {
                case Side.Top:
                    var t = Canvas.GetTop(control);
                    var t_n = t + v.Y;
                    if(t_n != 0)
                        Canvas.SetTop(control, t_n);
                    else if(t_n <= 0)
                        Canvas.SetTop(control, 0);
                    break;
                case Side.Bottom:
                    var b = Canvas.GetBottom(control);
                    var b_n = b + v.Y;
                    if (b_n != 0)
                        Canvas.SetBottom(control, b_n);
                    else if (b_n <= 0)
                        Canvas.SetBottom(control, 0);
                    break;
                case Side.Left:
                    var l = Canvas.GetLeft(control);
                    var l_n = l + v.X;
                    if(l_n != 0)
                        Canvas.SetLeft(control, l_n);
                    else if(l_n <= 0)
                        Canvas.SetLeft(control, 0);
                    break;
                case Side.Right:
                    var r = Canvas.GetLeft(control);
                    var r_n = r + v.X;
                    if(r_n != 0)
                        Canvas.SetRight(control, r_n);
                    else if(r_n <= 0)
                        Canvas.SetRight(control, 0);
                    break;
            }
        }
        public static void NewSizeByCorner(this Control control, VectorEventArgs e, Corner corner)
        {
            var v = e.Vector;
            var x_ = v.X;
            var y_ = v.Y;
            switch (corner)
            {
                case Corner.TopLeft:
                    var tl1 = Canvas.GetTop(control);
                    var tl2 = Canvas.GetLeft(control);
                    if(tl1 <= 0 || tl2 <= 0)
                    {

                    }
                    else
                    {

                    }

                    break;
                case Corner.TopRight:
                    var tr1 = Canvas.GetTop(control);
                    var tr2 = Canvas.GetRight(control);
                    if(tr1 == 0 || tr2 == 0)
                    {

                    }

                    break;
                case Corner.BottomLeft:
                    var bl1 = Canvas.GetBottom(control);
                    var bl2 = Canvas.GetLeft(control);
                    if(bl1 <= 0 || bl2 <= 0)
                    {

                    }

                    break;
                case Corner.BottomRight:
                    var br1 = Canvas.GetBottom(control);
                    var br2 = Canvas.GetRight(control);

                    break;
            }
        }
    }

    public enum Side
    {
        Left,
        Right,
        Top,
        Bottom
    }
    public enum Corner
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}
