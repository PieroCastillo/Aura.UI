using Avalonia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Helpers
{
    public static class RectHelper
    {
        public static bool CheckInOut(Rect rect1, Rect rect2)
        {
            return rect1.Intersects(rect2);
        }

    }
}
