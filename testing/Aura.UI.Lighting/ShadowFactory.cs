using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Lighting
{
    public static class ShadowFactory
    {
        public static BoxShadows Create(Color color,
                                        double blur = 5,
                                        double anchor = 0,
                                        double offsetX = 0,
                                        double offsetY = 0,
                                        bool inset = false)
                                        => new BoxShadows(
                                        new BoxShadow 
                                        { 
                                            Color = color, 
                                            Blur = blur, 
                                            IsInset = inset,
                                            OffsetX = offsetX, 
                                            OffsetY = offsetY,
                                            Spread = anchor
                                        });
    }
}
