using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Metadata;

namespace Aura.UI.Controls
{
    public partial class RadialSlider
    {
        private double _radius;
        public double Radius
        {
            get => _radius;
            private set => SetAndRaise(RadiusProperty, ref _radius, value);
        }
        public static readonly DirectProperty<RadialSlider, double> RadiusProperty =
            AvaloniaProperty.RegisterDirect<RadialSlider, double>(nameof(Radius), o => o.Radius);

        public int StrokeWidth
        {
            get => GetValue(StrokeWidthProperty);
            set => SetValue(StrokeWidthProperty, value);
        }

        public static readonly StyledProperty<int> StrokeWidthProperty =
            AvaloniaProperty.Register<RadialSlider, int>(nameof(StrokeWidth), 20);

        public Color ForegroundColor
        {
            get => GetValue(ForegroundColorProperty);
            set => SetValue(ForegroundColorProperty, value);
        }

        public readonly static StyledProperty<Color> ForegroundColorProperty =
            AvaloniaProperty.Register<RadialSlider, Color>(nameof(ForegroundColor));

        public Color BackgroundColor
        {
            get => GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public readonly static StyledProperty<Color> BackgroundColorProperty =
            AvaloniaProperty.Register<RadialSlider, Color>(nameof(BackgroundColor));

        private double x_angle;

        public double XAngle
        {
            get => x_angle;
            protected set => SetAndRaise(XAngleProperty, ref x_angle, value);
        }

        private readonly static DirectProperty<RadialSlider, double> XAngleProperty =
            AvaloniaProperty.RegisterDirect<RadialSlider, double>(nameof(XAngle), o => o.XAngle);

        private double y_angle;

        public double YAngle
        {
            get => y_angle;
            protected set => SetAndRaise(YAngleProperty, ref y_angle, value);
        }

        private readonly static DirectProperty<RadialSlider, double> YAngleProperty =
            AvaloniaProperty.RegisterDirect<RadialSlider, double>(nameof(YAngle), o => o.YAngle);

        public int RoundDigits
        {
            get => GetValue(RoundDigitsProperty);
            set => SetValue(RoundDigitsProperty, value);
        }

        public static readonly StyledProperty<int> RoundDigitsProperty =
            AvaloniaProperty.Register<RadialSlider, int>(nameof(RoundDigits), 0);


        private Control _Child;

        [Content]
        public Control Child
        {
            get => _Child;
            set => SetAndRaise(ChildProperty, ref _Child, value);
        }

        public static readonly DirectProperty<RadialSlider, Control> ChildProperty =
            AvaloniaProperty.RegisterDirect<RadialSlider, Control>(nameof(Child), o => o.Child, (o, v) => o.Child = v);
    }
}
