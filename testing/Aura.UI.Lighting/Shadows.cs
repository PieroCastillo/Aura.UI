using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Lighting
{
    public static class Shadows
    {
        public static BoxShadows DefaultShadow => new BoxShadows(new BoxShadow { Blur = 5, Color = Colors.Gray });
        public static BoxShadows DefaultInsetShadow => new BoxShadows(new BoxShadow { Blur = 5, Color = Colors.Gray, IsInset = true});
    }
}