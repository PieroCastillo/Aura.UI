using Aura.UI.Extensions;
using Aura.UI.Helpers;
using Aura.UI.Rendering;
using Aura.UI.UIExtensions;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Aura.UI.Controls.Components
{
    public class TrianglePicker : TemplatedControl
    {
        private Ellipse _thumb;
        private bool _pressed;

        static TrianglePicker()
        {
            AffectsMeasure<TrianglePicker>(ColorParentProperty);
            RadialColorSlider.RadiusProperty.Changed.AddClassHandler<TrianglePicker>((x, e) => x.InvalidateMeasure());
            ClipToBoundsProperty.OverrideDefaultValue<TrianglePicker>(false);
            //IsPointerOverProperty.Changed.Subscribe(IspointreroverChg);
        }

        private static void IspointreroverChg(AvaloniaPropertyChangedEventArgs<bool> e)
        {
            if(e.Sender is TrianglePicker t)
            {
                switch (e.NewValue.Value && t._pressed)
                {
                    case true:
                        if(t.ColorParent is not null)
                        {
                            t.ColorParent.Lock();
                        }
                        break;
                    case false:
                        if (t.ColorParent is not null)
                        {
                            t.ColorParent.UnLock();
                        }

                        break;
                }
            }
        }

        private void UpdateValuesFromPoint(Point p)
        {
            if (!Helpers.Maths.TriangleContains(new(0.5f * Bounds.Width, 0), new(0f, Bounds.Height), new(Bounds.Width, Bounds.Height), p))
                return;

            Point p1 = new(0.5f * Bounds.Width, 0);
            Point p2 = new(0f, Bounds.Height); 
            Point p3 = new(Bounds.Width, Bounds.Height);

            var saturationD = Helpers.Maths.DistanceBetweenTwoPoints(p1, p2);
            var valueD = Helpers.Maths.DistanceBetweenTwoPoints(p1, p3);

            var saturationAD = Helpers.Maths.DistanceBetweenTwoPoints(p, p2);
            var valueAD = Helpers.Maths.DistanceBetweenTwoPoints(p, p3);

            var perSat = Helpers.Maths.PercentageOf(saturationD, saturationAD);
            var perVal = Helpers.Maths.PercentageOf(valueD, valueAD);

            Saturation = Math.Clamp(perSat, 0, 100);
            ValueColor = Math.Clamp(perVal, 0, 100);
        }

        private void UpdateSelectorPosition(Point p)
        {
            if (!Helpers.Maths.TriangleContains(new(0.5f * Bounds.Width, 0), new(0f, Bounds.Height), new(Bounds.Width, Bounds.Height), p))
              return;

            if(_thumb is not null && _thumb.RenderTransform is TranslateTransform tt)
            {
                tt.X = p.X - (Bounds.Width / 2);
                tt.Y = p.Y - (Bounds.Height / 2);
            }
        }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            base.OnPointerMoved(e);
            if (_pressed)
            {
                var p = e.GetCurrentPoint(this).Position;
                UpdateValuesFromPoint(p);
                UpdateSelectorPosition(p);
            }
        }

        protected override void OnPointerLeave(PointerEventArgs e)
        {
            base.OnPointerLeave(e);
            _pressed = false;

            if (ColorParent is not null)
                ColorParent.UnLock();
            e.Handled = true;
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            base.OnPointerReleased(e);
            _pressed = false;

            if (ColorParent is not null)
                ColorParent.UnLock();

            e.Handled = true;
        }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            _pressed = true;

            if (ColorParent is not null)
                ColorParent.Lock();
            e.Handled = true;
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);

            _thumb = this.GetControl<Ellipse>(e, "thumb");

        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if(ColorParent is not null)
            {
                var r = ColorParent.Radius;
                var side = Helpers.Maths.TriangleSideByRadius(r);
                var w = side;// * 0.85;
                var h = Helpers.Maths.TriangleHeightBySide(side);// * 0.85;
                Debug.WriteLine(r + " :radius");
                Debug.WriteLine(w.ToString() + " :width");
                Debug.WriteLine(h.ToString() + " :height");

                var sz = new Size(w, h);

                Debug.WriteLine(availableSize + " :available size");
                Debug.WriteLine(sz + " :new size");
                return sz;
            }
            else
            {
                return base.MeasureOverride(availableSize);
            }
        }

        public Color Hue
        {
            get => GetValue(HueProperty);
            set => SetValue(HueProperty, value);
        }
        public static readonly StyledProperty<Color> HueProperty = AvaloniaProperty.Register<TrianglePicker, Color>(nameof(Hue), Colors.Red);

        private RadialColorSlider _colorparent;
        public RadialColorSlider ColorParent
        {
            get => _colorparent;
            set => SetAndRaise(ColorParentProperty, ref _colorparent, value);
        }
        public static readonly DirectProperty<TrianglePicker, RadialColorSlider> ColorParentProperty =
            AvaloniaProperty.RegisterDirect<TrianglePicker, RadialColorSlider>(nameof(ColorParent), o => o.ColorParent, (o,v) => o.ColorParent = v);

        public double Saturation
        {
            get => GetValue(SaturationProperty);
            set => SetValue(SaturationProperty, value);
        }

        public static readonly StyledProperty<double> SaturationProperty =
            AvaloniaProperty.Register<RadialColorSlider, double>(nameof(Saturation));

        public double ValueColor
        {
            get => GetValue(ValueColorProperty);
            set => SetValue(ValueColorProperty, value);
        }

        public static readonly StyledProperty<double> ValueColorProperty =
            AvaloniaProperty.Register<RadialColorSlider, double>(nameof(ValueColor));


        private double _XPosition;
        public double XPosition
        {
            get => _XPosition;
            private set => SetAndRaise(XPositionProperty, ref _XPosition, value);
        }

        public static readonly DirectProperty<TrianglePicker, double> XPositionProperty =
            AvaloniaProperty.RegisterDirect<TrianglePicker, double>(nameof(XPosition), o => o.XPosition);


        private double _YPosition;
        public double YPosition
        {
            get => _YPosition;
            private set => SetAndRaise(YPositionProperty, ref _YPosition, value);
        }

        public static readonly DirectProperty<TrianglePicker, double> YPositionProperty =
            AvaloniaProperty.RegisterDirect<TrianglePicker, double>(nameof(YPosition), o => o.YPosition);


    }
}
