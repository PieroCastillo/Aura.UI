using Aura.UI.Helpers;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using System;
using System.Diagnostics;

namespace Aura.UI.Controls
{
    public partial class RadialSlider : RangeBase
    {
        bool pressed;

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
            if (e.Sender is RadialSlider r)
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
    }
}
