using Aura.UI.Rendering;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Data;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Aura.UI.Controls.Colouring
{
    public class Arc : Control, IStyleable
    {
        Type IStyleable.StyleKey { get => typeof(Arc); } 

        static Arc()
        {
            AffectsRender<Arc>(ArcColorProperty);
            AffectsRender<Arc>(StrokeProperty);
            AffectsRender<Arc>(StartAngleProperty);
            AffectsRender<Arc>(SweepAngleProperty);
        }

        public Color ArcColor
        {
            get => GetValue(ArcColorProperty);
            set => SetValue(ArcColorProperty, value);
        }
        public readonly static StyledProperty<Color> ArcColorProperty =
            AvaloniaProperty.Register<Arc, Color>(nameof(ArcColor), Colors.SkyBlue, inherits: true, defaultBindingMode: BindingMode.TwoWay);

        public int Stroke
        {
            get => GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }
        public readonly static StyledProperty<int> StrokeProperty =
            AvaloniaProperty.Register<Arc, int>(nameof(Stroke), 10, inherits: true, defaultBindingMode: BindingMode.TwoWay);

        public double StartAngle
        {
            get => GetValue(StartAngleProperty);
            set => SetValue(StartAngleProperty, value);
        }
        public readonly static StyledProperty<double> StartAngleProperty =
            AvaloniaProperty.Register<Arc, double>(nameof(StartAngle), -90, inherits: true, defaultBindingMode: BindingMode.TwoWay);

        public double SweepAngle
        {
            get => GetValue(SweepAngleProperty);
            set => SetValue(SweepAngleProperty, value);
        }
        public static readonly StyledProperty<double> SweepAngleProperty =
            AvaloniaProperty.Register<Arc, double>(nameof(SweepAngle), 180, inherits: true, defaultBindingMode: BindingMode.TwoWay);

        public override void Render(DrawingContext context)
        {
            context.Custom(new ArcRender(Bounds, null, Stroke, (float)StartAngle, (float)SweepAngle, ArcColor));
            Debug.WriteLine("Arc painted");
        }
    }
}
