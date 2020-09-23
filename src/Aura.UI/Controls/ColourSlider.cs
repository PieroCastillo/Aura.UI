using Aura.UI.Attributes;
using Aura.UI.Controls.Primitives;
using Aura.UI.Controls.Thumbs;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls
{
    /// <summary>
    /// This control shows a Slider with <see cref="ColourThumb"/> as Thumbs
    /// DO NOT USE USE THIS CONTROL, IT IS DEVELOPING IN THIS MOMENT
    /// </summary>
    [InDeveloping]
    [DonotUse(Reason = "It's in developing")]
    public class ColourSlider : SliderBase<Color>
    {
        public IGradientBrush GetGradient()
        {
            var grad = new LinearGradientBrush();
            double offset = 1 / SelectableThumbs.Count;
            foreach (ColourThumb t in SelectableThumbs)
            {
                var stop = new GradientStop(t.Value, t.RelativePosition );
                grad.GradientStops.Add(stop);
            }
            return grad;
        }
    }
}
