using Aura.UI.Extensions;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;
using static Aura.UI.Extensions.NumberExtensions;

namespace Aura.UI.Controls.Neumorphism
{
    public class Neumor : Control
    {
        public Color First = Colors.Black;
        public Color Second = Colors.White.WithAlpha(FromFloat(.5f));
        public IBrush Background = Brushes.Black;
        public NeumorphismShape Shape = NeumorphismShape.Flat;

        public int Radius;
        public int Distance;
        public float Intensity;
        public int Blur;

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            switch (Shape)
            {
                case NeumorphismShape.Flat:

                    break;
                case NeumorphismShape.Concave:
                    break;
                case NeumorphismShape.Convex:
                    break;
                case NeumorphismShape.Pressed:
                    break;
            }
        }
    }

    public enum NeumorphismShape
    {
        Flat,
        Concave,
        Convex,
        Pressed
    }

    public enum NeumorphismLightDirection : int
    {
        TopLeft = 1,
        TopRight = 2,
        BottomRight = 3,
        BottomLeft = 4,
    }
}
