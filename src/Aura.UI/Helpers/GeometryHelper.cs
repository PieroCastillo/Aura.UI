using Avalonia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Helpers
{
    public static class GeometryHelper
    {
        public static Size EquilateralTriangleBySide(double side)
        {
            var w = side;
            var h = Math.Sqrt(3) * side / 2;

            return new Size(w, h);
        }
    }
}
