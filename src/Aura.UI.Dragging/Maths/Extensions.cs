using Avalonia;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Aura.UI.Dragging.Maths
{
    public static class Extensions
    {
        public static double Module(this Vector v, Vector vn)
            => Math.Abs(Math.Sqrt(Math.Pow(v.X - vn.X, 2) + Math.Pow(v.Y - vn.Y, 2)));

        public static double Module(this Point point, Point p)
            => Math.Abs(Math.Sqrt(Math.Pow(point.X - p.X, 2) + Math.Pow(point.Y - p.Y, 2)));
    }
}
