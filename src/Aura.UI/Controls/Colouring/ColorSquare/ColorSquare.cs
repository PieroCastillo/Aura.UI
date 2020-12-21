using Aura.UI.Rendering;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Colouring
{
    public partial class ColorSquare : Control
    {
        public override void Render(DrawingContext context)
        {
            context.Custom(new ColorSquareRender(Bounds, null, ColorToRender, Colors.LightGray));
        }
    }
}
