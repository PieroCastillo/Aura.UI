using Aura.UI.Helpers;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Aura.UI.Controls
{
    public class RadialSlider : RangeBase
    {
        static RadialSlider()
        {
            MaximumProperty.Changed.Subscribe(CalibrateAngles);
            MinimumProperty.Changed.Subscribe(CalibrateAngles);
            ValueProperty.Changed.Subscribe(CalibrateAngles);
            ClipToBoundsProperty.OverrideDefaultValue<RadialSlider>(false);

            BoundsProperty.Changed.Subscribe(UpdateRadius);
            StrokeWidthProperty.Changed.Subscribe(UpdateRadius);


            MaximumProperty.OverrideMetadata<RadialSlider>(new DirectPropertyMetadata<double>(100));
            MinimumProperty.OverrideMetadata<RadialSlider>(new DirectPropertyMetadata<double>(0));
            ValueProperty.OverrideMetadata<RadialSlider>(new DirectPropertyMetadata<double>(25));

            AffectsRender<RadialSlider>(XAngleProperty, YAngleProperty);
        }

        bool pressed;
        private bool _locked = false;
        public void Lock()
        {
            _locked = true;
        }

        public void UnLock()
        {
            _locked = false;
        }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            base.OnPointerMoved(e);
            if (pressed)
            {
                UpdateValueFromPoint(e.GetCurrentPoint(this).Position);
            }
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            pressed = true;
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);
            pressed = false;
        }

        protected virtual void UpdateValueFromPoint(Point p)
        {
            var angle = Maths.AngleOf(p, Radius).ToDegrees();
            Value = Math.Round(Maths.ValueFromMinMaxAngle(angle, Minimum, Maximum), RoundDigits);
        }

        private static void UpdateRadius(AvaloniaPropertyChangedEventArgs e)
        {
            if(e.Sender is RadialSlider r)
            {
                r.Radius = (r.Bounds.Width - (r.StrokeWidth * 2)) / 2;
                Debug.WriteLine("radius updated");
            }
        }

        private static void CalibrateAngles(AvaloniaPropertyChangedEventArgs<double> e)
        {
            var pr = e.Sender as RadialSlider;

            if (pr != null)
            {
                pr.XAngle = -90;
                pr.YAngle = Maths.AngleFromMinMaxValue(pr.Value, pr.Minimum, pr.Maximum);

                pr.InvalidateVisual();
            }
        }

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
    }
}
