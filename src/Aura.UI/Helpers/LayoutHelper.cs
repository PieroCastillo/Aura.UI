using ABI.Windows.Foundation;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Aura.UI.Helpers
{
    public static class LayoutHelper
    {
        public const double MagicNumber = 1.2;

        public static void NewSizeBySide(this Control control, VectorEventArgs e, Side side)
        {
            var old_m = control.Margin;
            var v = e.Vector;
            unsafe { 
            switch (side)
            {
                case Side.Top:
                    var new_m_t = new Thickness(old_m.Left,v.Y / MagicNumber,old_m.Right,old_m.Bottom);
                    control.Margin = new_m_t;

                    control.Height += v.Y;
                    break;
                case Side.Bottom:
                    var new_m_b = new Thickness(old_m.Left, old_m.Top, old_m.Right, -v.Y / MagicNumber);

                    control.Height += v.Y;
                    control.Margin = new_m_b;
                    break;
                case Side.Left:
                    var new_m_l = new Thickness(v.X / MagicNumber, old_m.Top, old_m.Right, old_m.Bottom);
                    control.Margin = new_m_l;

                    control.Width += v.X;
                    break;
                case Side.Right:
                    var new_m_r = new Thickness(old_m.Left, old_m.Top, -v.X / MagicNumber, old_m.Bottom);
                    control.Margin = new_m_r;

                    control.Width += v.X;
                    break;
            }
           }
        }
        public static void NewSizeByCorner(this Control control, VectorEventArgs e, Corner corner)
        {
            var v = e.Vector;
#if DEBUG
            var sw = new Stopwatch();
            sw.Start();
#endif
            var old_m = control.Margin;
            unsafe
            {
                switch (corner)
                {
                    case Corner.TopLeft:
                        control.Margin = new Thickness(v.X / MagicNumber, v.Y / MagicNumber, old_m.Right, old_m.Bottom);
                        control.Height += v.Y;
                        control.Width += v.X;
                        break;
                    case Corner.TopRight:
                        control.Margin = new Thickness(old_m.Left, v.Y / MagicNumber, -v.X /MagicNumber, old_m.Bottom);

                        //control.Height += v.Y;
                        //control.Width += v.X;
                        break;
                    case Corner.BottomLeft:
                        control.Margin = new Thickness(v.X / MagicNumber, old_m.Top, old_m.Right, -v.Y / MagicNumber);

                        control.Height += v.Y;
                        control.Width += v.X;
                        break;
                    case Corner.BottomRight:
                        control.Margin = new Thickness(old_m.Left, old_m.Top, -v.X / MagicNumber, -v.Y / MagicNumber);

                        control.Height += v.Y;
                        control.Width += v.X;
                        break;
                }
            }
#if DEBUG
            sw.Stop();
            Debug.WriteLine($"The resize by corner toke {sw.Elapsed.TotalMilliseconds} ms");
#endif
        }

        public static void MoveByDrag(this Control control, VectorEventArgs e)
        {
#if DEBUG
            var sw = new Stopwatch();
            sw.Start();
#endif
            var p = e.Vector;
            var m = control.Margin;
            control.Margin = new Thickness((m.Left + p.X )/MagicNumber, (m.Top + p.Y)/MagicNumber, 
                                            -(- p.X - m.Right)/MagicNumber, -(- p.Y - m.Bottom)/MagicNumber);
#if DEBUG
            sw.Stop();
            Debug.WriteLine($"The resize by corner toke {sw.Elapsed.TotalMilliseconds} ms");
#endif
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
