using Avalonia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Extensions
{
    public static class RectExtensions
    {
        public static Rect WithoutPosition(this Rect rect) => new Rect(0,0, rect.Width, rect.Height);
    }
}
