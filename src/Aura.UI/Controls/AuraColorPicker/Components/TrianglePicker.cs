using Aura.UI.Helpers;
using Aura.UI.Rendering;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Aura.UI.Controls.Components
{
    public class TrianglePicker : TemplatedControl
    {
        static TrianglePicker()
        {
            AffectsMeasure<TrianglePicker>(ColorParentProperty);
            RadialColorSlider.RadiusProperty.Changed.AddClassHandler<TrianglePicker>((x, e) => x.InvalidateMeasure());
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if(ColorParent is not null)
            {
                var r = ColorParent.Radius;
                var side = Helpers.Maths.TriangleSideByRadius(r);
                var w = side;
                var h = Helpers.Maths.TriangleHeightBySide(side);
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

        protected override Size ArrangeOverride(Size finalSize)
        {
            InvalidateMeasure();
            return base.ArrangeOverride(finalSize);
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            context.Custom(new TriangleWheelRender(Bounds, Hue, null));
        }

        public Color Hue
        {
            get => GetValue(HueProperty);
            set => SetValue(HueProperty, value);
        }
        public StyledProperty<Color> HueProperty = AvaloniaProperty.Register<TrianglePicker, Color>(nameof(Hue), Colors.Red);

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


    }
}
