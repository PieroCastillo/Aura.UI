using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;

namespace Aura.UI.Controls.Components
{
    public class RadialColorSlider : RadialSlider
    {
        static RadialColorSlider()
        {
            MinimumProperty.OverrideMetadata<RadialColorSlider>(new DirectPropertyMetadata<double>(0));
            MaximumProperty.OverrideMetadata<RadialColorSlider>(new DirectPropertyMetadata<double>(360));
        }
    }
}
