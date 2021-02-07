using Aura.UI.Rendering;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Media;
using Avalonia.Threading;

namespace Aura.UI.Controls.Colouring
{
    public class Arc : Control
    {
        static Arc()
        {
            AffectsRender<Arc>(ArcColorProperty,
                              StrokeProperty,
                              StartAngleProperty,
                              SweepAngleProperty);
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
            context.Custom(new ArcRender(new Rect(0, 0, Bounds.Width, Bounds.Height), null, Stroke, (float)StartAngle, (float)SweepAngle, ArcColor));
            Dispatcher.UIThread.InvokeAsync(InvalidateVisual, DispatcherPriority.Background);
        }
    }
}