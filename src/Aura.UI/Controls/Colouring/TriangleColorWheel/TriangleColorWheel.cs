using Aura.UI.Rendering;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura.UI.Controls.Colouring
{
    public class TriangleColorWheel : Control
    {
        static TriangleColorWheel()
        {
            AffectsRender<TriangleColorWheel>(ColorProperty);
        }

        public override void Render(DrawingContext context)
        {
            context.Custom(new TriangleWheelRender(Bounds, Color, null, (float)StrokeWidth));
            base.Render(context);
        }

        public Color Color
        {
            get => GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static readonly StyledProperty<Color> ColorProperty =
            AvaloniaProperty.Register<TriangleColorWheel, Color>(nameof(Color));



        public double StrokeWidth
        {
            get => GetValue(StrokeWidthProperty);
            set => SetValue(StrokeWidthProperty, value);
        }

        public static readonly StyledProperty<double> StrokeWidthProperty =
            AvaloniaProperty.Register<TriangleColorWheel, double>(nameof(StrokeWidth), 20);


    }
}
