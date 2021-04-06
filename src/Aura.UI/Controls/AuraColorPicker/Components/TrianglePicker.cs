using Aura.UI.Rendering;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.AuraColorPicker.Components
{
    public class TrianglePicker : TemplatedControl
    {
        public override void Render(DrawingContext context)
        {
            base.Render(context);

            context.Custom(new TriangleWheelRender(Bounds, Hue, Bounds.Width, null));
        }

        public Color Hue
        {
            get;
            set;
        }
    }
}
