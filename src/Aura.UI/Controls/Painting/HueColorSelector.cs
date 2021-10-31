using Aura.UI.Extensions;
using Avalonia;
using Avalonia.Input;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Painting
{
    public class HueColorSelector : RadialSlider
    {
        static HueColorSelector()
        {
            ClipToBoundsProperty.OverrideDefaultValue<HueColorSelector>(false);
            MaximumProperty.OverrideMetadata<HueColorSelector>(new DirectPropertyMetadata<double>(360));
            MinimumProperty.OverrideMetadata<HueColorSelector>(new DirectPropertyMetadata<double>(0));
            ValueProperty.OverrideMetadata<HueColorSelector>(new DirectPropertyMetadata<double>(25));
        }
    }
}
